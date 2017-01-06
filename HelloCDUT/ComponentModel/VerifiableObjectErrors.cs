using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.ComponentModel
{
    public class VerifiableObjectErrors : IReadOnlyList<string>
    {
        private List<string> _messages = new List<string>();

        private ObservableCollection<ValidationResult> _results = new ObservableCollection<ValidationResult>();

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
                //var result = _results.Where(x => x.MemberNames.Contains(propertyName));
                //return result.First().ErrorMessage;
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