using WebStoryFroEveryting.Services.UnderwaterHunterServices.Interfaces;

namespace WebStoryFroEveryting.Services.UnderwaterHunterServices
{
    public class HuntersNumber : IHuntersNumber
    {
        private int minNumberOfHuntersForCreating = 2;

        public int GetMinHuntersNumber()
        {
            return minNumberOfHuntersForCreating;
        }
    }
}
