using System;
using System.Windows;
using TFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Experiences
{
    public class ExperienceModel
    {
        /// <summary>
        /// Unique name of the experience option
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pack Uri to the image resource
        /// </summary>
        public Uri ImageUri { get; set; }

        /// <summary>
        /// Description of the experience option
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// MEF exported name of the experience option
        /// </summary>
        public string ExperienceClass { get; set; }

        public static class ExperiencesType
        {
            public const string Experience1 = "NombreDeExperiencia1";
            public const string Experience2 = "NombreDeExperiencia2";
            public const string Experience3 = "NombreDeExperiencia3";
            public const string Experience4 = "NombreDeExperiencia4";
            public const string Experience5 = "NombreDeExperiencia5";
            public const string Experience6 = "NombreDeExperiencia6";
            public const string TypeDefinitionExperience = "Type Definition";
            public const string TypeIdentificationExperience = "Type Identification";
            public const string TypeBinaryConverter = "Binary Convert";
            public const string TypeDecimalConverter = "Decimal Convert";
        }

        internal static FrameworkElement GetNewTestingExperience(string ExperienceClass, object args)
        {
            switch (ExperienceClass)
            {
                case ExperiencesType.TypeDefinitionExperience:
                    return new TypeDefinition(args);
                case ExperiencesType.TypeIdentificationExperience:
                    return new TypeIdentification(args);
                case ExperiencesType.TypeBinaryConverter:
                    return new BinaryConvert(args);
                case ExperiencesType.TypeDecimalConverter:
                    return new DecimalConvert(args);
                default:
                    throw new InvalidOperationException(string.Format(Properties.Resources.UnExistingExperienceType, ExperienceClass));
            }
        }
    }
}
