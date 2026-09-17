using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class UnitTemplateDto
    {
        public int Id { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string MainUnitName { get; set; } = string.Empty;
        public string? UnitSmallName { get; set; }
        public List<UnitFactorDto> UnitFactors { get; set; } = new();
    }
    public class UnitFactorDto
    {
        public int Id { get; set; }
        public string FactorName { get; set; } = string.Empty;
        public decimal Factor { get; set; }
        public string? SmallName { get; set; }
    }
}
