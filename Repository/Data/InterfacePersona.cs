using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface InterfacePersona
    {
        bool add(PersonaModel persona);
        bool remove(string persona);
        bool update(PersonaModel persona);
        PersonaModel get(string id);
        IEnumerable<PersonaModel> list();

    }
}
