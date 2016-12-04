using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyLogger
{

    class OWLClassAndPropertiesSuggestion
    {

        private List<String> owlClasses;
        private List<String> owlObjectProperties;

        public OWLClassAndPropertiesSuggestion(List<String> owlClasses, List<String> owlObjectProperties)
        {
            this.owlClasses = owlClasses;
            this.owlObjectProperties = owlObjectProperties;
        }


        public List<String> OwlClasses
        {
            get
            {
                return owlClasses;
            }

            set
            {
                owlClasses = value;
            }
        }

        public List<String> OwlObjectProperties
        {
            get
            {
                return owlObjectProperties;
            }

            set
            {
                owlObjectProperties = value;
            }
        }
    }
}
