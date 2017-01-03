using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.ComponentModel
{
    public class VerifiableObjectErrors : IReadOnlyList<string>
    {
        private List<string> _messages = new List<string>();

        private List<ValidationResult> _results = new List<ValidationResult>();

        internal VerifiableObjectErrors(VerifiableBase verifiableBase)
        {
            ValidationContext context = new ValidationContext(verifiableBase);
            Validator.TryValidateObject(verifiableBase, context, _results, true);
            foreach (var result in _results)
            {
                _messages.Add(result.ErrorMessage);
            }
        }

        public int Count
        {
            get
            {
                return _messages.Count;
            }
        }

        public string this[int index]
        {
            get
            {
                return _messages[index];
            }
        }

        public string this[string propertyName]
        {
            get
            {
                foreach (var result in _results)
                {
                    if (result.MemberNames.Contains(propertyName))
                    {
                        return result.ErrorMessage;
                    }
                }
                return null;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _messages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}