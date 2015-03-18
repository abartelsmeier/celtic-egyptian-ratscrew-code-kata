using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata
{
    public class SnapValidator: ISnapRule
    {
        private List<ISnapRule> m_Rules;

        public SnapValidator(List<ISnapRule> rules)
        {
            m_Rules = rules;

        }
        
        public bool IsSnap(Stack stack)
        {
           return false;
        }
    }
}