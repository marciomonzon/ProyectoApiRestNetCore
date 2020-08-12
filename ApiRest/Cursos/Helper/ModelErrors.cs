using System.Collections.Generic;

namespace Cursos.Helper
{
    public class ModelErrors
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public List<string> Messages { get; set; }
    }
}
