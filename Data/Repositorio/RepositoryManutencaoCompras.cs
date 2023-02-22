using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data.Repositorio
{
    public class RepositoryManutencaoCompras : RepositoryGenerics<ManutencaoCompras>, IManutencaoCompras
    {

        async Task<List<ManutencaoCompras>> IManutencaoCompras.MontaFiltro(FiltroComprasManutencao filtroManutencaoCompras)
        {

            //var list = new List<ManutencaoCompras>();
            string sql = string.Empty;
            var QtdeComprometida = false;


            if ((filtroManutencaoCompras.tipoValor == 1) && (filtroManutencaoCompras.tipo != "Encomenda/Faltas"))
            {
                sql = sql + (" select ");
                sql = sql + ("    foo.codigogrupo, ");
                sql = sql + ("    foo.codigoproduto, ");
                sql = sql + ("    foo.estoque, ");
                sql = sql + ("    foo.descricaoproduto, ");
                sql = sql + ("    foo.codigolaboratorio, ");
                sql = sql + ("    foo.nomelaboratorio, ");
                sql = sql + ("    foo.siglaunidade, ");
                sql = sql + ("    foo.curvaabcproduto, ");
                sql = sql + ("    foo.estoqueminimoproduto, ");
                sql = sql + ("    foo.estoquemaximoproduto, ");
                sql = sql + ("    foo.custoreferenciaproduto, ");
                sql = sql + ("    foo.fatorreferenciaproduto, ");
                sql = sql + ("    foo.codigocas, ");
                sql = sql + ("    foo.iddcb, ");
                sql = sql + ("    foo.codigodcb, ");
                sql = sql + ("    foo.codigobarraproduto, ");
                sql = sql + ("    sum(foo.qtdevendida) as qtdevendida ");
                sql = sql + ("    from ( ");
            }

            sql = sql + ("select ");
            sql = sql + ("    p.codigogrupo, ");
            sql = sql + ("    p.codigoproduto, ");

            if (filtroManutencaoCompras.filialId != 0)
            {

                sql = sql + (" ( (select	sum(( select rsaldoproduto from data.pegasaldos(p.codigogrupo, p.codigoproduto, codigofilial, current_date))) ");
                sql = sql + (" from	data.filial ");
                sql = sql + (" WHERE	(select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(codigofilial as character varying)  || ''%''  ) ";
            }
            else
            {
                //   if (fm_Senha.vmb_IntegracaoMatrizFilial)
                //  sql = sql + ("    ((select distinct sum((select rsaldoproduto from data.pegasaldos(p.codigogrupo, p.codigoproduto, f.codigofilial,current_date))) from data.filial f where  ( (select * from data.retornafilial(false,f.codigofilial)  )  like ''%''||f.codigofilial||''%'") )   ")
                //   else
                sql = sql + ("    ((select rsaldoproduto from data.pegasaldos(p.codigogrupo, p.codigoproduto, null, current_date))");
            }

            if (QtdeComprometida)
            {
                if (filtroManutencaoCompras.filialId != 0)
                {

                    sql = sql + (" -  (select sum(quantidadecomprometidalote) from data.lote where codigogrupo=p.codigogrupo and codigoproduto = p.codigoproduto  ");
                    sql = sql + (" and	(select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(codigofilial as character varying)  || ''%'";
                }
                else
                    sql = sql + (" - (select coalesce(sum(quantidadecomprometidalote), 0) from data.lote where codigogrupo=p.codigogrupo and codigoproduto = p.codigoproduto) ");
            }

            sql = sql + (") as estoque, ");

            sql = sql + ("    p.descricaoproduto, ");
            sql = sql + ("    p.codigolaboratorio, ");
            sql = sql + ("    l.nomelaboratorio as nomelaboratorio, ");
            sql = sql + ("    p.siglaunidadeestoque as siglaunidade, ");
            sql = sql + ("    case when(p.curvaabcproduto = 0) then 'A' else ");
            sql = sql + ("    case when(p.curvaabcproduto = 1) then 'B' else ");
            sql = sql + ("    case when(p.curvaabcproduto = 2) then 'C' else  '-' end end ");
            sql = sql + ("    end AS curvaabcproduto, ");
            sql = sql + (" (case (select parametro.estoqueminimofilial from data.parametro) when 1 then  ");
            sql = sql + (" (select sum(e.estoqueminimo) from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and ");
            sql = sql + ("  e.codigoproduto = p.codigoproduto  ");

            //v.codigofilial

            if (filtroManutencaoCompras.filialId != 0)
            {
                {
                    sql = sql + ("  and e.codigofilial = ");
                    sql = sql + (filtroManutencaoCompras.filialId);
                }
                sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ";


                sql = sql + ("   ) else ");
                sql = sql + ("  p.estoqueminimoproduto end ) as estoqueminimoproduto, ");
            }
            else
            {
                sql = sql + ("  and e.codigofilial = ");
                sql = sql + ("   0) else ");
                sql = sql + ("  p.estoqueminimoproduto end ) as estoqueminimoproduto, ");
            }

            sql = sql + (" (case (select parametro.estoqueminimofilial from data.parametro) when 1 then  ");
            sql = sql + (" (select sum(e.estoquemaximo) from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and ");
            sql = sql + ("  e.codigoproduto = p.codigoproduto  ");

            if (filtroManutencaoCompras.filialId != 0)
            {
                {
                    sql = sql + ("  and e.codigofilial = ");
                    sql = sql + (filtroManutencaoCompras.filialId);
                }
                sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ";



                sql = sql + ("   ) else ");
                sql = sql + ("  p.estoquemaximoproduto end ) as estoquemaximoproduto, ");
            }
            else
            {
                sql = sql + ("  and e.codigofilial = ");
                sql = sql + ("   0) else ");
                sql = sql + ("  p.estoquemaximoproduto end ) as estoquemaximoproduto, ");
            }

            sql = sql + ("    p.custoreferenciaproduto, ");
            sql = sql + ("    p.fatorreferenciaproduto, ");
            sql = sql + ("    p.codigocas, ");
            sql = sql + ("    p.iddcb, ");
            sql = sql + ("    p.codigodcb, ");
            sql = sql + ("    p.codigobarraproduto ");

            if (filtroManutencaoCompras.tipo == "Venda")
            {
                sql = sql + (",( ");
                sql = sql + ("    COALESCE((select ");
                sql = sql + ("      sum(iv.quantidadeitemvenda) ");
                sql = sql + ("      from data.itemvenda iv ");
                sql = sql + ("     inner join  data.venda v on (v.numerovenda = iv.numerovenda and iv.codigogrupo = p.codigogrupo and iv.codigoproduto = p.codigoproduto) ");
                sql = sql + ("     where ");
                sql = sql + ("      1 = 1 ");

                if (filtroManutencaoCompras.filialId != 0)
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ";

                //sql = sql + ("      and v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor));

                sql = sql + ("      and v.statusvenda = 1 ");
                sql = sql + ("      and v.orcamentovenda = 0 ");
                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'" + "),0) ";
                sql = sql + ("  ) as qtdevendida ");

                //    sql = sql + ("      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) >= ' + AddColuna(ItemCompras.Compra.DataInicial.GetDataFmtAmericano + ' ' + ItemCompras.Compra.HoraInicial.Valor, true) + ' ");
                //    sql = sql + ("      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) <= ' + AddColuna(ItemCompras.Compra.DataFinal.GetDataFmtAmericano + ' ' + ItemCompras.Compra.HoraFinal.Valor, true) + "),0) ");
                //sql = sql + ("  ) as qtdevendida ");
            }
            else
      if (filtroManutencaoCompras.tipo == "Demanda")
            {
                sql = sql + (",( ");
                sql = sql + ("    COALESCE((select ");
                sql = sql + ("     sum(iv.quantidadeitemvenda) ");
                sql = sql + ("     from ");
                sql = sql + ("      data.itemvenda iv ");
                sql = sql + ("     inner join data.venda v on ( ");

                if (filtroManutencaoCompras.filialId != 0)
                    //sql = sql + ("      v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor) + ' and ");
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' and ";


                sql = sql + ("        v.numerovenda = iv.numerovenda and ");
                sql = sql + ("        iv.codigogrupo = p.codigogrupo and ");
                sql = sql + ("        iv.codigoproduto = p.codigoproduto and ");
                sql = sql + ("        v.statusvenda = 1 and ");
                sql = sql + ("        v.orcamentovenda = 0  ");


                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'";
                sql = sql + ("    )),0)  ");
                sql = sql + ("    + ");
                sql = sql + ("    COALESCE((select ");
                sql = sql + ("     sum(iv.quantidadeunidadeestoque) ");
                sql = sql + ("     from ");
                sql = sql + ("      data.itemordemproducao iv ");
                sql = sql + ("      inner join data.ordemproducao v on ( ");

                if (filtroManutencaoCompras.filialId != 0)
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' and ";

                //sql = sql + ("      v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor) + ' and ");

                sql = sql + ("         iv.numeroordemproducao = v.numeroordemproducao and ");
                sql = sql + ("         v.anoordemproducao = iv.anoordemproducao and ");
                sql = sql + ("         iv.codigogrupo = p.codigogrupo and ");
                sql = sql + ("         iv.codigoproduto = p.codigoproduto and ");
                sql = sql + ("         iv.anoordemproducao = " + DateTime.Parse(filtroManutencaoCompras.vendaDe).Year);
                sql = sql + ("         and v.statusordemproducao = 2  ");
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'";
                sql = sql + ("       ) ");
                sql = sql + ("     inner join data.itemformulavenda ifv on (ifv.numeroformula = v.numeroformula and ifv.numerovenda = v.numerovenda and ifv.codigogrupo = p.codigogrupo and ifv.codigoproduto = p.codigoproduto) ");
                sql = sql + ("    ), 0) ");
                sql = sql + ("    + ");
                sql = sql + ("    coalesce((select ");
                sql = sql + ("     sum(iv.quantidadeunidadeestoque) ");
                sql = sql + ("     from ");
                sql = sql + ("      data.itemordemproducao iv ");
                sql = sql + ("      inner join data.ordemproducao v on ( ");

                if (filtroManutencaoCompras.filialId != 0)
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' and ";

                //sql = sql + ("      v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor) + ' and ");

                sql = sql + ("         iv.numeroordemproducao = v.numeroordemproducao and ");
                sql = sql + ("         v.anoordemproducao = iv.anoordemproducao and ");
                sql = sql + ("         iv.codigogrupo = p.codigogrupo and ");
                sql = sql + ("         iv.codigoproduto = p.codigoproduto and ");
                sql = sql + ("         V.statusordemproducao = 2 and ");
                sql = sql + ("         iv.anoordemproducao = " + DateTime.Parse(filtroManutencaoCompras.vendaDe).Year);
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'";
                sql = sql + ("      and   COALESCE(v.numerovenda, 0) = 0 ");
                sql = sql + ("    ) ");
                sql = sql + ("   inner join data.movimentoproduto mp on (mp.anoordemproducao = iv.anoordemproducao and mp.numeroordemproducao = iv.numeroordemproducao and mp.codigogrupo = p.codigogrupo and ");
                sql = sql + ("   mp.codigoproduto = p.codigoproduto and mp.codigomovimentoproduto = (select max(mp1.codigomovimentoproduto) from data.movimentoproduto mp1 where mp1.anoordemproducao = iv.anoordemproducao and");
                sql = sql + ("   mp1.numeroordemproducao = iv.numeroordemproducao and mp1.codigogrupo = p.codigogrupo and mp1.codigoproduto = p.codigoproduto)) ");
                sql = sql + ("    ) ");
                sql = sql + ("    ,0) ");
                sql = sql + ("      ) as qtdevendida ");
            }
            else
                sql = sql + (" ,cast(0 as double precision) as qtdevendida ");

            sql = sql + ("from data.produto p ");
            sql = sql + ("left join data.laboratorio l on (p.codigolaboratorio = l.codigolaboratorio)  ");

            {
                if ((filtroManutencaoCompras.tipo == "Venda") || (filtroManutencaoCompras.tipo == "Demanda"))
                {
                    sql = sql + ("  ,data.venda v  ");
                    sql = sql + ("  ,data.itemvenda iv ");
                }
            }
            if (filtroManutencaoCompras.tipo == "Encomenda/Faltas")
            {
                sql = sql + ("  join data.faltasencomendas f on (p.codigogrupo = f.codigogrupo and p.codigoproduto = f.codigoproduto and f.status = 0)");
            }

            sql = sql + (" where 1 = 1 ");

            if (filtroManutencaoCompras.tipo == "Venda")
            {
                sql = sql + ("and ( ");
                sql = sql + ("    COALESCE((select ");
                sql = sql + ("      sum(iv.quantidadeitemvenda) ");
                sql = sql + ("     from ");
                sql = sql + ("      data.itemvenda iv ");
                sql = sql + ("     inner join data.venda v on (v.numerovenda = iv.numerovenda and iv.codigogrupo = p.codigogrupo and iv.codigoproduto = p.codigoproduto) ");
                sql = sql + ("     where ");
                sql = sql + ("      1 = 1 ");

                if (filtroManutencaoCompras.filialId != 0)
                    //sql = sql + ("    and v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor));
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ";




                sql = sql + ("      and v.statusvenda = 1 ");
                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'";
                sql = sql + ("  ) > 0 ");
            }
            else
      if (filtroManutencaoCompras.tipo == "Demanda")
            {
                //sql = sql + (" ,sum(iv.quantidadeitemvenda) as qtdevendida                              ")
                sql = sql + ("and ( ");
                sql = sql + ("    COALESCE((select ");
                sql = sql + ("     sum(iv.quantidadeitemvenda) ");
                sql = sql + ("     from ");
                sql = sql + ("      data.itemvenda iv ");
                sql = sql + ("     inner join data.venda v on ( ");

                if (filtroManutencaoCompras.filialId != 0)
                    //sql = sql + ("    v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor)+' and ");
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' and ";



                sql = sql + ("        v.numerovenda = iv.numerovenda and ");
                sql = sql + ("        iv.codigogrupo = p.codigogrupo and ");
                sql = sql + ("        iv.codigoproduto = p.codigoproduto and ");
                sql = sql + ("        v.statusvenda = 1 and ");
                sql = sql + ("        v.orcamentovenda = 0  ");
                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'";
                sql = sql + ("    )),0)  ");
                sql = sql + ("    + ");
                sql = sql + ("    COALESCE((select ");
                sql = sql + ("     sum(iv.quantidadeunidadeestoque) ");
                sql = sql + ("     from ");
                sql = sql + ("      data.itemordemproducao iv ");
                sql = sql + ("      inner join data.ordemproducao v on ( ");

                if (filtroManutencaoCompras.filialId != 0)
                    //sql = sql + ("    v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor)+' and ");
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' and ";




                sql = sql + ("         iv.numeroordemproducao = v.numeroordemproducao and ");
                sql = sql + ("         v.anoordemproducao = iv.anoordemproducao and ");
                sql = sql + ("         iv.codigogrupo = p.codigogrupo and ");
                sql = sql + ("         iv.codigoproduto = p.codigoproduto and ");
                sql = sql + ("         iv.anoordemproducao = " + DateTime.Parse(filtroManutencaoCompras.vendaDe).Year);
                sql = sql + ("         and v.statusordemproducao = 2 ");
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'";
                sql = sql + ("       ) ");
                sql = sql + ("     inner join data.itemformulavenda ifv on (ifv.numeroformula = v.numeroformula and ifv.numerovenda = v.numerovenda and ifv.codigogrupo = p.codigogrupo and ifv.codigoproduto = p.codigoproduto) ");
                sql = sql + ("    ), 0) ");
                sql = sql + ("    + ");
                sql = sql + ("    coalesce((select ");
                sql = sql + ("     sum(iv.quantidadeunidadeestoque) ");
                sql = sql + ("     from ");
                sql = sql + ("      data.itemordemproducao iv ");
                sql = sql + ("      inner join data.ordemproducao v on ( ");

                if (filtroManutencaoCompras.filialId != 0)
                    //sql = sql + ("    v.codigofilial = '+inttostr(ItemCompras.Compra.Filial.valor)+' and ");
                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' and ";




                sql = sql + ("         iv.numeroordemproducao = v.numeroordemproducao and ");
                sql = sql + ("         v.anoordemproducao = iv.anoordemproducao and ");
                sql = sql + ("         iv.codigogrupo = p.codigogrupo and ");
                sql = sql + ("         iv.codigoproduto = p.codigoproduto and ");
                sql = sql + ("         V.statusordemproducao = 2  ");
                sql = sql + ("         and iv.anoordemproducao = " + DateTime.Parse(filtroManutencaoCompras.vendaDe).Year);
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) >= '" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'";
                sql = sql + "      and cast(cast(v.dataemissaoordemproducao as date) + cast(v.horaemissaoordemproducao as time) as timestamp) <= '" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'";
                sql = sql + ("       and ");
                sql = sql + ("        COALESCE(v.numerovenda, 0) = 0 ");
                sql = sql + ("    ) ");
                sql = sql + ("   inner join data.movimentoproduto mp on (mp.anoordemproducao = iv.anoordemproducao and mp.numeroordemproducao = iv.numeroordemproducao and mp.codigogrupo = p.codigogrupo and mp.codigoproduto = p.codigoproduto and ");
                sql = sql + ("   mp.codigomovimentoproduto = (select max(mp1.codigomovimentoproduto) from data.movimentoproduto mp1 where mp1.anoordemproducao = iv.anoordemproducao and ");
                sql = sql + ("   mp1.numeroordemproducao = iv.numeroordemproducao and mp1.codigogrupo = p.codigogrupo and mp1.codigoproduto = p.codigoproduto)) ");
                sql = sql + ("    ) ");
                sql = sql + ("    ,0) ");
                sql = sql + ("  ) > 0 ");
            }

            sql = sql + (" and p.inativoproduto = 0 "); //Michel Tarefa #372 - 02/04/2014
            sql = sql + (" and coalesce(p.inativocompras, 0) = 0 ");
            //Inicio Michel Tarefa #372 - 02/04/2014
            if ((filtroManutencaoCompras.tipo == "Encomenda/Faltas") && (filtroManutencaoCompras.filialId != 0))
            {
                //sql = sql + (" and f.codigofilial = ");
                //sql = sql + (AddColuna(ItemCompras.Compra.Filial, true));

                //sql = sql + ("  and     (select * from data.retornafilial("+inttostr(ItemCompras.Compra.Filial.valor)+") )  like ''%'' ||cast(f.codigofilial as character varying)  || ''%''  ");
                sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ";


            }
            //Fim Michel  Tarefa #372 - 02/04/2014

            {
                if ((filtroManutencaoCompras.tipo == "Venda") || (filtroManutencaoCompras.tipo == "Demanda"))
                {
                    //Início Michel #547
                    sql = sql + (" and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) >=  ");
                    sql = sql + ("'" + filtroManutencaoCompras.vendaDe + ' ' + filtroManutencaoCompras.vendaDeHora + "'");
                    sql = sql + (" and cast(cast(v.dataemissaovenda as date) + cast(v.horaemissaovenda as time) as timestamp) <= ");
                    sql = sql + ("'" + filtroManutencaoCompras.vendaAte + ' ' + filtroManutencaoCompras.vendaAteHora + "'");
                    //Fim Michel #547

                    if (filtroManutencaoCompras.filialId != 0)
                    {
                        sql = sql + (" and v.codigofilial = ");
                        sql = sql + (filtroManutencaoCompras.filialId, true);
                    }
                }
            }
            // Alisson - 16/10/2014 - #738 - Inicio

            if (filtroManutencaoCompras.gruposIds.Count > 0)
                sql = sql + (" and p.codigogrupo in (" + filtroManutencaoCompras.gruposIds + ") ");

            if ((filtroManutencaoCompras.gruposIds == null) && (filtroManutencaoCompras.produtosIds != null))
            {
                sql = sql + (" and p.codigoproduto = ");
                sql = sql + (filtroManutencaoCompras.produtosIds[0], true);
            }

            {
                if ((filtroManutencaoCompras.gruposIds.Count > 0) && (filtroManutencaoCompras.produtosIds.Count > 0))
                {
                    sql = sql + (" and p.codigogrupo = ");
                    sql = sql + (filtroManutencaoCompras.gruposIds[0]);
                }

                if ((filtroManutencaoCompras.gruposIds.Count > 0) && (filtroManutencaoCompras.produtosIds != null))
                {
                    sql = sql + (" and p.codigogrupo = ");
                    sql = sql + (filtroManutencaoCompras.gruposIds[0]);
                    sql = sql + (" and p.codigoproduto = ");
                    sql = sql + (filtroManutencaoCompras.produtosIds[0]);
                }
            }

            // Alisson - 16/10/2014 - #738 - Fim

            if (filtroManutencaoCompras.laboratorioId != 0)
            {
                sql = sql + (" and p.codigolaboratorio = ");
                sql = sql + (filtroManutencaoCompras.laboratorioId);
            }

            if ((filtroManutencaoCompras.curvaAbc != null) && (filtroManutencaoCompras.curvaAbc != "Geral"))
            {
                if (filtroManutencaoCompras.curvaAbc == "A")
                    sql = sql + (" and p.curvaabcproduto = 0 ");
                else
                if (filtroManutencaoCompras.curvaAbc == "B")
                    sql = sql + (" and p.curvaabcproduto = 1 ");
                else
                if (filtroManutencaoCompras.curvaAbc == "C")
                    sql = sql + (" and p.curvaabcproduto = 2 ");
            }

            if (filtroManutencaoCompras.tipo == "Estoque Mínimo")
            {
                sql = sql + ("and (case (select parametro.estoqueminimofilial from data.parametro) when 1 then ");
                sql = sql + ("(select sum(e.estoqueminimo) from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and");
                sql = sql + ("e.codigoproduto = p.codigoproduto ");


                sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ");

                //sql = sql + ("   and (select * from data.retornafilial(" + inttostr(ItemCompras.Compra.Filial.valor) + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ");

                sql = sql + (") else");
                sql = sql + ("p.estoqueminimoproduto end ) > 0");


                sql = sql + ("and (case (select parametro.estoqueminimofilial from data.parametro) when 1 then  ");
                sql = sql + ("(select sum(e.estoqueminimo) from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and");
                //sql = sql + (" (select e.estoqueminimo from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and ");
                //sql = sql + ("  e.codigoproduto = p.codigoproduto and e.codigofilial = ");
                sql = sql + ("  e.codigoproduto = p.codigoproduto ");

                if (filtroManutencaoCompras.filialId != 0)
                {
                    //sql = sql + (AddColuna(ItemCompras.Compra.Filial, true));
                    //sql = sql + ("   ) else ");

                    sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ";


                    sql = sql + ("   ) else ");

                    sql = sql + ("  p.estoqueminimoproduto end ) > 0 ");
                }
                else
                {
                    sql = sql + ("  and codigofilial = 0) else ");
                    sql = sql + ("  p.estoqueminimoproduto end ) > 0  ");
                }

                sql = sql + ("group by ");
                sql = sql + ("p.codigogrupo, ");
                sql = sql + ("p.codigoproduto, ");
                sql = sql + ("p.descricaoproduto, ");
                sql = sql + ("p.codigolaboratorio, ");
                sql = sql + ("p.siglaunidadeestoque, ");
                sql = sql + ("p.curvaabcproduto, ");
                //     sql = sql + ("p.estoqueminimoproduto,");
                sql = sql + ("l.nomelaboratorio, ");
                sql = sql + ("p.custoreferenciaproduto, ");
                sql = sql + ("p.fatorreferenciaproduto, ");
                sql = sql + ("p.codigocas, ");
                sql = sql + ("p.iddcb, ");
                sql = sql + ("p.codigodcb, ");
                sql = sql + ("p.codigobarraproduto ");
                //     sql = sql + ("having estoqueminimoproduto > 0 ");
            }
            else
            {
                if ((filtroManutencaoCompras.tipo == "Venda") || (filtroManutencaoCompras.tipo == "Demanda") || (filtroManutencaoCompras.tipo == "Encomenda / Faltas"))
                {
                    sql = sql + ("group by ");
                    sql = sql + ("p.codigogrupo, ");
                    sql = sql + ("p.codigoproduto, ");
                    sql = sql + ("p.descricaoproduto, ");
                    sql = sql + ("p.codigolaboratorio, ");
                    sql = sql + ("p.siglaunidadeestoque, ");
                    sql = sql + ("p.curvaabcproduto, ");
                    sql = sql + ("l.nomelaboratorio, ");
                    sql = sql + ("p.estoqueminimoproduto,");
                    sql = sql + ("p.custoreferenciaproduto, ");
                    sql = sql + ("p.fatorreferenciaproduto,  ");
                    sql = sql + ("p.codigocas,  ");
                    sql = sql + ("p.iddcb,  ");
                    sql = sql + ("p.codigodcb,  ");
                    sql = sql + ("p.codigobarraproduto  ");
                }

                if ((filtroManutencaoCompras.tipoValor == 1) && (filtroManutencaoCompras.tipo != "Encomenda/Faltas"))
                {
                    sql = sql + (" union ");
                    sql = sql + ("select ");
                    sql = sql + ("    p.codigogrupo, ");
                    sql = sql + ("    p.codigoproduto, ");

                    if (filtroManutencaoCompras.filialId != 0)
                    {
                        //sql = sql + ("    ((select rsaldoproduto from data.pegasaldos(p.codigogrupo, p.codigoproduto, '+IntToStr(ItemCompras.Compra.Filial.Valor)+', current_date))")

                        sql = sql + (" ( (select	sum(( select rsaldoproduto from data.pegasaldos(p.codigogrupo, p.codigoproduto, codigofilial, current_date))) ");
                        sql = sql + (" from	data.filial ");

                        sql = sql + (" WHERE (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' )";


                    }
                    else
                        sql = sql + ("    ((select distinct sum((select rsaldoproduto from data.pegasaldos(p.codigogrupo, p.codigoproduto, f.codigofilial,current_date))) from data.filial f)");

                    sql = sql + (") as estoque, ");
                    sql = sql + ("    p.descricaoproduto, ");
                    sql = sql + ("    p.codigolaboratorio, ");
                    sql = sql + ("    l.nomelaboratorio, ");
                    sql = sql + ("    p.siglaunidadeestoque as siglaunidade, ");
                    sql = sql + ("    case when(p.curvaabcproduto = 0) then 'A' else ");
                    sql = sql + ("    case when(p.curvaabcproduto = 1) then 'B' else ");
                    sql = sql + ("    case when(p.curvaabcproduto = 2) then 'C' else  '-' end end ");
                    sql = sql + ("    end AS curvaabcproduto, ");
                    sql = sql + (" (case (select parametro.estoqueminimofilial from data.parametro) when 1 then  ");
                    sql = sql + (" (select sum(e.estoqueminimo) from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and");
                    //sql = sql + (" (select e.estoqueminimo from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and ");
                    //sql = sql + ("  e.codigoproduto = p.codigoproduto and e.codigofilial = ");
                    sql = sql + ("  e.codigoproduto = p.codigoproduto ");

                    if (filtroManutencaoCompras.filialId != 0)
                    {
                        {
                            sql = sql + (filtroManutencaoCompras.filialId);
                            sql = sql + ("   ) else ");
                            sql = sql + ("  p.estoqueminimoproduto end ) as estoqueminimoproduto,  ");
                        }

                        sql = sql + ("      and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' ";

                        sql = sql + (") else");
                        sql = sql + ("p.estoqueminimoproduto end ) as estoqueminimoproduto,  ");
                    }
                    else
                    {
                        sql = sql + ("  and e.codigofilial = 0) else ");
                        sql = sql + ("  p.estoqueminimoproduto end ) as estoqueminimoproduto,  ");
                    }



                    //*-----------------------------------------------------------------------------*//
                    sql = sql + (" (case (select parametro.estoqueminimofilial from data.parametro) when 1 then  ");
                    sql = sql + (" (select sum(e.estoquemaximo) from data.estoqueminimofilial e where e.codigogrupo = p.codigogrupo and ");
                    sql = sql + ("  e.codigoproduto = p.codigoproduto  ");

                    if (filtroManutencaoCompras.filialId != 0)
                    {


                        sql = sql + (" and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' )";



                        sql = sql + ("   ) else ");
                        sql = sql + ("  p.estoquemaximoproduto end ) as estoquemaximoproduto, ");
                    }
                    else
                    {
                        sql = sql + ("  and e.codigofilial = ");
                        sql = sql + ("   0) else ");
                        sql = sql + ("  p.estoquemaximoproduto end ) as estoquemaximoproduto, ");
                    }

                    //*-----------------------------------------------------------------------------*//





                    sql = sql + ("    p.custoreferenciaproduto, ");
                    sql = sql + ("    p.fatorreferenciaproduto, ");
                    sql = sql + ("    p.codigocas, ");
                    sql = sql + ("    p.iddcb, ");
                    sql = sql + ("    p.codigodcb, ");
                    sql = sql + ("    p.codigobarraproduto ");
                    sql = sql + (" ,cast(0 as double precision) as qtdevendida ");

                    sql = sql + ("from ");
                    sql = sql + ("    data.produto p ");
                    sql = sql + ("    left join data.laboratorio l on (p.codigolaboratorio = l.codigolaboratorio)");
                    sql = sql + ("  join data.faltasencomendas f on (p.codigogrupo = f.codigogrupo and p.codigoproduto = f.codigoproduto and f.status = 0)");
                    sql = sql + (" where 1 = 1 ");
                    sql = sql + (" and p.inativoproduto = 0 "); //Michel Tarefa #372 - 02/04/2014
                    sql = sql + (" and coalesce(p.inativocompras, 0) = 0 ");

                    // Alisson - 16/10/2014 - #738 - Inicio

                    if (filtroManutencaoCompras.gruposIds.Count > 0)
                        sql = sql + (" and p.codigogrupo in (" + filtroManutencaoCompras.gruposIds[0] + ") ");

                    if ((filtroManutencaoCompras.gruposIds.Count > 0) && (filtroManutencaoCompras.produtosIds != null))
                    {
                        sql = sql + (" and p.codigoproduto = ");
                        sql = sql + (filtroManutencaoCompras.produtosIds[0]);
                    }

                    {
                        if ((filtroManutencaoCompras.gruposIds.Count > 0) && (filtroManutencaoCompras.produtosIds != null))
                        {
                            sql = sql + (" and p.codigogrupo = ");
                            sql = sql + (filtroManutencaoCompras.gruposIds[0]);
                        }

                        if ((filtroManutencaoCompras.gruposIds.Count > 0) && (filtroManutencaoCompras.produtosIds != null))
                        {
                            sql = sql + (" and p.codigogrupo = ");
                            sql = sql + (filtroManutencaoCompras.gruposIds[0]);
                            sql = sql + (" and p.codigoproduto = ");
                            sql = sql + (filtroManutencaoCompras.produtosIds[0]);
                        }
                    }

                    // Alisson - 16/10/2014 - #738 - Fim

                    //Inicio Michel Tarefa #372 - 02/04/2014
                    if (filtroManutencaoCompras.filialId != 0)
                    {
                        {
                            sql = sql + (" and f.codigofilial = ");
                            sql = sql + (filtroManutencaoCompras.filialId);
                        }


                        sql = sql + (" and (select * from data.retornafilial(" + filtroManutencaoCompras.considerarApenasFilialSelecionada, "true", "false") + ',' + filtroManutencaoCompras.filialId + ") )  like ''%'' ||cast(e.codigofilial as character varying)  || ''%'' )";

                    }
                    //Fim Michel  Tarefa #372 - 02/04/2014

                    if (filtroManutencaoCompras.laboratorioId != 0)
                    {
                        sql = sql + (" and p.codigolaboratorio = ");
                        sql = sql + (filtroManutencaoCompras.laboratorioId);
                    }

                    if ((filtroManutencaoCompras.curvaAbc != null) && (filtroManutencaoCompras.curvaAbc != "Geral"))
                    {
                        if (filtroManutencaoCompras.curvaAbc == "A")
                            sql = sql + (" and p.curvaabcproduto = 0 ");
                        else
                        if (filtroManutencaoCompras.curvaAbc == "B")
                            sql = sql + (" and p.curvaabcproduto = 1 ");
                        else
                        if (filtroManutencaoCompras.curvaAbc == "C")
                            sql = sql + (" and p.curvaabcproduto = 2 ");
                    }

                    if (filtroManutencaoCompras.tipo == "Estoque Mínimo")
                    {
                        sql = sql + ("group by ");
                        sql = sql + ("p.codigogrupo, ");
                        sql = sql + ("p.codigoproduto, ");
                        sql = sql + ("p.descricaoproduto, ");
                        sql = sql + ("p.codigolaboratorio, ");
                        sql = sql + ("l.nomelaboratorio, ");
                        sql = sql + ("p.siglaunidadeestoque, ");
                        sql = sql + ("p.curvaabcproduto, ");
                        sql = sql + ("p.estoqueminimoproduto, ");
                        sql = sql + ("p.custoreferenciaproduto, ");
                        sql = sql + ("p.fatorreferenciaproduto, ");
                        sql = sql + ("p.codigocas, ");
                        sql = sql + ("p.iddcb, ");
                        sql = sql + ("p.codigodcb, ");
                        sql = sql + ("p.codigobarraproduto ");
                        sql = sql + ("having estoqueminimoproduto > 0 ");
                    }
                    else
                 if ((filtroManutencaoCompras.tipo == "Venda") || (filtroManutencaoCompras.tipo == "Demanda") || (filtroManutencaoCompras.tipo == "Encomenda/Faltas"))
                    {
                        sql = sql + ("group by ");
                        sql = sql + ("p.codigogrupo, ");
                        sql = sql + ("p.codigoproduto, ");
                        sql = sql + ("p.descricaoproduto, ");
                        sql = sql + ("p.codigolaboratorio, ");
                        sql = sql + ("l.nomelaboratorio, ");
                        sql = sql + ("p.siglaunidadeestoque, ");
                        sql = sql + ("p.curvaabcproduto, ");
                        sql = sql + ("p.estoqueminimoproduto, ");
                        sql = sql + ("p.custoreferenciaproduto, ");
                        sql = sql + ("p.fatorreferenciaproduto, ");
                        sql = sql + ("p.codigocas, ");
                        sql = sql + ("p.iddcb, ");
                        sql = sql + ("p.codigodcb, ");
                        sql = sql + ("p.codigobarraproduto ");
                    }

                    sql = sql + (" ) as Foo ");
                    sql = sql + (" group by ");
                    sql = sql + ("    foo.codigogrupo, ");
                    sql = sql + ("    foo.codigoproduto, ");
                    sql = sql + ("    foo.estoque, ");
                    sql = sql + ("    foo.descricaoproduto, ");
                    sql = sql + ("    foo.codigolaboratorio, ");
                    sql = sql + ("    foo.nomelaboratorio, ");
                    sql = sql + ("    foo.siglaunidade, ");
                    sql = sql + ("    foo.curvaabcproduto, ");
                    sql = sql + ("    foo.estoqueminimoproduto, ");
                    sql = sql + ("    foo.estoquemaximoproduto, ");  //Stanley 03/12/2021
                    sql = sql + ("    foo.custoreferenciaproduto, ");
                    sql = sql + ("    foo.fatorreferenciaproduto, ");
                    sql = sql + ("    foo.codigocas, ");
                    sql = sql + ("    foo.iddcb, ");
                    sql = sql + ("    foo.codigodcb, ");
                    sql = sql + ("    foo.codigobarraproduto ");
                }
            }

            sql = sql + ("order by descricaoproduto ");

            List<ManutencaoCompras> mmm = new List<ManutencaoCompras>();

            using (var context = new ContextBase(this._OptionsBuilder))
            {

                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            ManutencaoCompras mj = new ManutencaoCompras();
                            //mj.codigogrupo = int.Parse(result["codigogrupo"].ToString());
                            mj.descricaoproduto = result["descricaoproduto"].ToString();
                            mj.estoque = result["estoque"] != null ? double.Parse(result["estoque"].ToString()) : 0;
                            mj.curvaabcproduto = result["curvaabcproduto"].ToString();
                            mj.estoquemaximoproduto = result["estoquemaximoproduto"].ToString() != "" ? double.Parse(result["estoquemaximoproduto"].ToString()) : 0;
                            mj.estoqueminimoproduto = result["estoqueminimoproduto"].ToString() != "" ? double.Parse(result["estoqueminimoproduto"].ToString()) : 0;
                            mj.codigogrupo = result["codigogrupo"].ToString() != "" ? double.Parse(result["codigogrupo"].ToString()) : 0;
                            mj.nomelaboratorio = result["nomelaboratorio"].ToString();

                            mmm.Add(mj);
                        }
                        context.Database.CloseConnection();

                    }
                }



            }

            return mmm;
        }



    }
}

