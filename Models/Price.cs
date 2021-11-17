using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace project.pole.Models
{
    public enum TypePrice
    {
        [Display(Name = "Отбор поверхностных проб грунта")]
        SamplingSurfaceSoilSamples, 
        
        [Display(Name = "Отбор грунта из скважин на гаммо-спектометрию")]
        SamplingSoilFromWellsGammaSpectrometry,
        
        [Display(Name = "Отбор грунта из скважин на сонетарно-химическое обследование")]
        SoilSamplingFromWellsFsanitaryAndChemicalInspection, 
        
        [Display(Name = "γ-съемка. Полевые работы")]
        GammasHootingFieldWork,
        
        [Display(Name = "γ-съемка. Камеральные работы")]
        GammasHootingDeskWork,
        
        [Display(Name = "γ-спектрометрия")]
        GammaSpectrometry,
        
        [Display(Name = "Измерение плотности потока радона из грунта. Полевые работы")]
        MeasurementRadonFluxDensityFromGroundFieldWork,
        
        [Display(Name = "Измерение плотности потока радона из грунта. Камеральные работы")]
        MeasurementRadonFluxDensityFromGroundDeskWork,
        
        [Display(Name = "Измерение плотности потока радона из грунта. Бета-спектрометрия")]
        MeasurementRadonFluxDensityFromGroundBetaSpectrometry,
        
        [Display(Name = "Пробоподготовка")]
        SamplePreparation,
        
        [Display(Name = "Определение тяжелых металлов")]
        DeterminationHeavyMetals,
        
        [Display(Name = "Определение нефтепродуктов")]
        DefinitionPetroleumProducts,
        
        [Display(Name = "Определение бензапирена")]
        DefinitionBenzopyrene,
        
        [Display(Name = "Санитарно - экологическая экспертиза инструментальных и лабораторных исследований в составе предпроектной(проектной) документации с гигиеническими рекомендациями(радиация)")]
        SanitaryEnvironmentalExpertiseRadiation,
        
        [Display(Name = "Санитарно-экологическая экспертиза инструментальных и лабораторных исследований в составе предпроектной (проектной) документации с гигиеническими рекомендациями (химия и бактериология)")]
        SanitaryEnvironmentalExpertiseChemistryAndBacteriology,
        
        [Display(Name = "Бактериология")]
        Bacteriology
    }
    
    public class Price: BaseModel
    {
        [DisplayName("Тип")]
        public TypePrice TypePrice { get; set; }
        [DisplayName("Цена")]
        public double PriceValue { get; set; }
    }
}