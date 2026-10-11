namespace WebApplication1.Models
{
    /// <summary>
    /// Modell for å vise feilinformasjon i en feilmeldingsside.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Id til forespørselen som feilet (kan være null).
        /// Brukes for å enklere finne igjen feilen i logger.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Returnerer true hvis RequestId har en verdi.
        /// Brukes i viewet til å avgjøre om RequestId skal vises.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

