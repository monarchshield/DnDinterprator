using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellInterpretator
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellCreator newspell = new SpellCreator();
            newspell.CreateSpell();
            newspell.SaveSpell();
        }
    }
}
