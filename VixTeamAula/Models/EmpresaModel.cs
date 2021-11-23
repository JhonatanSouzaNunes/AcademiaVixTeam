namespace VixTeamAula.Models
{
    public class EmpresaModel
    {
        public int codigo { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

    public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
