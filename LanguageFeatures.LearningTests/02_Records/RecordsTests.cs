using System;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LanguageFeatures.LearningTests
{
    public class FontSettings
    {
        public FontSettings(string family, int size)
        {
            Family = family;
            Size = size;
        }

        public string Family { get; }

        public int Size { get; }
    }

    public sealed class RecordsTests
    {
        /* Equality
        [Fact]
        public void Instances_With_Equal_Values_Should_Be_Equal()
        {
            var settings = DefaultFonts.Consolas;

            var identicalSettings = new FontSettings("Consolas", 16);
            
            settings.Should().BeAssignableTo<IEquatable<FontSettings>>();
            
            settings.Equals(identicalSettings).Should().BeTrue();
            (settings == identicalSettings).Should().BeTrue();
        }
        */

        /* Primary Constructor
        [Fact]
        public void Positional_Properties_Should_Be_Synthesized_As_Get_Init()
        {
            var settings = new FontSettings(
                Family: "Consolas",
                Size: 16)
            {
                Size = 24
            };

            settings.Size.Should().Be(24);
        }
        */
        
        /* ToString
        [Fact]
        public void Should_Have_Synthesize_ToString_Printing_All_Public_Members()
        {
            var settings = DefaultFonts.Consolas;

            settings.ToString().Should().Be($"{nameof(FontSettings)} {{ Family = Consolas, Size = 16 }}");
        }
        */

        /* Deconstructor
        [Fact]
        public void Should_Have_Synthesized_Destructor()
        {
            var settings = DefaultFonts.Consolas;

            var (fontFamily, fontSize) = settings;

            fontFamily.Should().Be("Consolas");
            fontSize.Should().Be(16);
        }
        */

        /* Derived Types
        [Fact]
        public void Synthesized_Equals_Implementation_Considers_Only_Records_Of_Same_Type_Equal()
        {
            static bool FontSettingsEqual(FontSettings left, FontSettings right) 
                => left.Equals(right);
        
            var defaultSettings = new FontSettings("Consolas", 16);
            var extendedSettings = new ExtendedFontSettings("Consolas", 16);

            FontSettingsEqual(defaultSettings, extendedSettings).Should().BeFalse();
            FontSettingsEqual(extendedSettings, defaultSettings).Should().BeFalse();
        }
        */

        /* WITH Expression
        [Fact]
        public void Should_Support_Special_Non_Destructive_Copy_With_Expression()
        {
            var consolasDefault = new ExtendedFontSettings("Consolas", 16);

            var italicEnlargedConsolas = consolasDefault with 
            {
                Size = 20,
                IsItalic = true
            };

            italicEnlargedConsolas.Family.Should().Be("Consolas");
            italicEnlargedConsolas.Size.Should().Be(20);
            italicEnlargedConsolas.IsItalic.Should().BeTrue();
            
            consolasDefault.Size.Should().Be(16);
            consolasDefault.IsItalic.Should().BeFalse();
        }
        */

        /* Serializers
        [Fact]
        public void System_Text_Json_Can_Serialize_And_Deserialize_Records()
        {
            var serializedSettings = JsonSerializer.Serialize(DefaultFonts.Consolas);
            serializedSettings.Should().Be(@"{""Family"":""Consolas"",""Size"":16}");

            var deserializedSettings = JsonSerializer.Deserialize<FontSettings>(serializedSettings);
            deserializedSettings.Should().Be(DefaultFonts.Consolas);
        }
        
        [Fact]
        public void Newtonsoft_Json_Can_Serialize_And_Deserialize_Records()
        {
            var serializedSettings = JsonConvert.SerializeObject(DefaultFonts.Consolas);
            serializedSettings.Should().Be(@"{""Family"":""Consolas"",""Size"":16}");

            var deserializedSettings = JsonConvert.DeserializeObject<FontSettings>(serializedSettings);
            deserializedSettings.Should().Be(DefaultFonts.Consolas);
        }
        */
    }
}