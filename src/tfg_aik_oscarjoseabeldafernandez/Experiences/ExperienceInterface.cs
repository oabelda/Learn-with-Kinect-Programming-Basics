using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Experiences
{
    public interface ExperienceInterface
    {
        void BackToMenu();
        void Retry();
        void Retry(int actualLevel);
        void Play();
        void Pause();
    }
}
