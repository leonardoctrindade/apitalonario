using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NomeAbreviado")]
        [Required(ErrorMessage = "Campo de nome abreviado não preenchido")]
        [MaxLength(20)]
        public string NomeAbreviado { get; set; }

        [Column("IdGrupoUsuario")]
        [Required(ErrorMessage = "Campo de Grupo não preenchido")]
        public int IdGrupoUsuario { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Column("Senha")]
        [Required(ErrorMessage = "Campo de senha não preenchido")]
        [MaxLength(10)]
        public string Senha { get; set; }

        [Column("Nivel")]
        public int Nivel { get; set; }

        [Column("Logon")]
        public bool Logon { get; set; }

        [Column("Email")]
        [MaxLength(60)]
        public string Email { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("LidoNovidade")]
        public bool LidoNovidade { get; set; }

        [Column("HoraUltimoAcesso")]
        public DateTime? HoraUltimoAcesso { get; set; }

        [Column("DataUltimoAcesso")]
        public DateTime? DataUltimoAcesso { get; set; }

        [Column("DataTrocaSenha")]
        public DateTime? DataTrocaSenha { get; set; }

        [Column("IdFilialUsuario")]
        public int IdFilialUsuario { get; set; }

        [Column("IdFilialProducao")]
        public int IdFilialProducao { get; set; }
    }
}
