using System.Text.Json.Serialization;

namespace Dima.Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(TData data, int totalCount, int currentPage, int pageSize) : base (data)
        {
            Data = data; //Recebe os dados que serão exibidos. Ex: Lista de itens
            TotalCount = totalCount; //Define o total de registros que serão exibidos
            CurrentPage = currentPage = 1; //Configura a página atual que o usuários está visualizando.
            PageSize = pageSize = Configuration.DefaultPageSize; //Especifica quantos registros cabem em cada página.
        }

        public PagedResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null) : base (data, code, message)
        {

        }
        public int CurrentPage { get; set; } //Pag atual
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize); // Total de pags
        public int PageSize { get; set; } = Configuration.DefaultPageSize; //Total de registros por páginas.

        public int TotalCount { get; set; } // Total de registos.
    }
}