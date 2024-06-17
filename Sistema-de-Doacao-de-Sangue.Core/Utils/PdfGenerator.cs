using iTextSharp.text;
using iTextSharp.text.pdf;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;

namespace Sistema_de_Doacao_de_Sangue.Core.Utils
{
    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GenerateRelatorioDoacoesPdf(IEnumerable<RelatorioDoacoesDTO> relatorio)
        {
            // Cria um MemoryStream para armazenar o PDF
            using (var ms = new MemoryStream())
            {
                // Cria um documento iTextSharp
                var document = new Document();
                
                // Inicializa o PdfWriter com o MemoryStream
                var writer = PdfWriter.GetInstance(document, ms);
                
                // Abre o documento para escrita
                document.Open();
                
                // Define as fontes para título, cabeçalho e corpo
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                var bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
                
                // Adiciona um título ao documento
                document.Add(new Paragraph("Relatório de Doações", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                });

                // Cria uma tabela com 4 colunas e largura de 100%
                var table = new PdfPTable(4) { WidthPercentage = 100 };
                // Define a largura relativa das colunas
                table.SetWidths(new float[] { 1, 2, 2, 2 });

                // Adiciona os cabeçalhos da tabela
                AddCellToHeader(table, "ID", headerFont);
                AddCellToHeader(table, "Doador", headerFont);
                AddCellToHeader(table, "Data", headerFont);
                AddCellToHeader(table, "Quantidade ML", headerFont);

                // Adiciona as linhas de dados à tabela
                bool alternate = false;
                foreach (var item in relatorio)
                {
                    var backgroundColor = alternate ? new BaseColor(230, 230, 250) : BaseColor.WHITE; // Alterna as cores das linhas
                    AddCellToBody(table, item.Id.ToString(), bodyFont, backgroundColor);
                    AddCellToBody(table, item.DoadorId.ToString(), bodyFont, backgroundColor);
                    AddCellToBody(table, item.DataDoacao.ToString("dd/MM/yyyy"), bodyFont, backgroundColor);
                    AddCellToBody(table, item.QuantidadeML.ToString(), bodyFont, backgroundColor);
                    alternate = !alternate; // Alterna a cor para a próxima linha
                }

                // Adiciona a tabela ao documento
                document.Add(table);
                
                // Fecha o documento
                document.Close();
                
                // Retorna o conteúdo do MemoryStream como um array de bytes
                return ms.ToArray();
            }
        }

        public byte[] GenerateRelatorioEstoquePdf(IEnumerable<RelatorioEstoqueDTO> relatorio)
        {
            // Cria um MemoryStream para armazenar o PDF
            using (var ms = new MemoryStream())
            {
                // Cria um documento iTextSharp
                var document = new Document();
                
                // Inicializa o PdfWriter com o MemoryStream
                var writer = PdfWriter.GetInstance(document, ms);
                
                // Abre o documento para escrita
                document.Open();
                
                // Define as fontes para título, cabeçalho e corpo
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                var bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
                
                // Adiciona um título ao documento
                document.Add(new Paragraph("Relatório de Estoque", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                });

                // Cria uma tabela com 3 colunas e largura de 100%
                var table = new PdfPTable(3) { WidthPercentage = 100 };
                // Define a largura relativa das colunas
                table.SetWidths(new float[] { 2, 2, 2 });

                // Adiciona os cabeçalhos da tabela
                AddCellToHeader(table, "Tipo Sanguíneo", headerFont);
                AddCellToHeader(table, "Fator Rh", headerFont);
                AddCellToHeader(table, "Quantidade Total ML", headerFont);

                // Adiciona as linhas de dados à tabela
                bool alternate = false;
                foreach (var item in relatorio)
                {
                    var backgroundColor = alternate ? new BaseColor(230, 230, 250) : BaseColor.WHITE; // Alterna as cores das linhas
                    AddCellToBody(table, item.TipoSanguineo, bodyFont, backgroundColor);
                    AddCellToBody(table, item.FatorRh, bodyFont, backgroundColor);
                    AddCellToBody(table, item.QuantidadeTotalML.ToString(), bodyFont, backgroundColor);
                    alternate = !alternate; // Alterna a cor para a próxima linha
                }

                // Adiciona a tabela ao documento
                document.Add(table);
                
                // Fecha o documento
                document.Close();
                
                // Retorna o conteúdo do MemoryStream como um array de bytes
                return ms.ToArray();
            }
        }

        // Método auxiliar para adicionar células de cabeçalho com estilo específico
        private void AddCellToHeader(PdfPTable table, string cellText, Font font)
        {
            var cell = new PdfPCell(new Phrase(cellText, font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new BaseColor(70, 130, 180); // Azul Steele para cabeçalho
            table.AddCell(cell);
        }

        // Método auxiliar para adicionar células de corpo com estilo específico
        private void AddCellToBody(PdfPTable table, string cellText, Font font, BaseColor backgroundColor)
        {
            var cell = new PdfPCell(new Phrase(cellText, font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = backgroundColor; // Define a cor de fundo
            table.AddCell(cell);
        }
    }
}
