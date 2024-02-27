using System.Collections.Generic;
using UniRx;

namespace SquaresAndCircles.Infrastructure.Saving
{
    public class SavingCaller
    {
        public SavingCaller(List<ISaver> savers)
        {
            Observable.EveryApplicationFocus()
                      .Subscribe(focus =>
                      {
                          if (focus) return;
                          Save(savers);
                      });

            Observable.OnceApplicationQuit()
                      .Subscribe(_ => Save(savers));
        }

        private void Save(List<ISaver> savers)
        {
            foreach (ISaver saver in savers)
            {
                saver.Save();
            }
        }
    }
}