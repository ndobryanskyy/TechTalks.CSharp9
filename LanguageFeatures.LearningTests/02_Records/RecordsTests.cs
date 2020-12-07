using System;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LanguageFeatures.LearningTests
{
    public class FontSettings
    {
        public FontSettings(string face, int size)
        {
            Face = face;
            Size = size;
        }

        public string Face { get; }

        public int Size { get; }
    }

    public sealed class RecordsTests
    {
        private static FontSettings ArialDefault { get; } 
            = new FontSettings("Arial", 16);
        
        /* Equality
        [Fact]
        public void Instances_With_Equal_Values_Should_Be_Equal()
        {
            var settings = ArialDefault;

            var identicalSettings = new FontSettings("Arial", 16);
            
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
                Family: "Arial",
                16)
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
            var settings = ArialDefault;

            settings.ToString().Should().Be($"{nameof(FontSettings)} {{ Family = Arial, Size = 16 }}");
        }
        */

        /* Destructor
        [Fact]
        public void Should_Have_Synthesized_Destructor()
        {
            var settings = ArialDefault;

            var (fontFamily, fontSize) = settings;

            fontFamily.Should().Be("Arial");
            fontSize.Should().Be(16);
        }
        */

        /* Derived_Types
        [Fact]
        public void Synthesized_Equals_Implementation_Considers_Only_Records_Of_Same_Type_Equal()
        {
            var defaultSettings = new FontSettings("Arial", 16);
            var extendedSettings = new ExtendedFontSettings("Arial", 16);

            FontSettingsEqual(defaultSettings, extendedSettings).Should().BeFalse();
            FontSettingsEqual(extendedSettings, defaultSettings).Should().BeFalse();

            static bool FontSettingsEqual(FontSettings left, FontSettings right) 
                => left.Equals(right);
        }
        */

        /* WITH Expression
        [Fact]
        public void Should_Support_Special_Non_Destructive_Copy_With_Expression()
        {
            var arialDefault = new ExtendedFontSettings("Arial", 16);

            var italicEnlargedArial = arialDefault with 
            {
                Size = 20,
                IsItalic = true
            };

            italicEnlargedArial.Family.Should().Be("Arial");
            italicEnlargedArial.Size.Should().Be(20);
            italicEnlargedArial.IsItalic.Should().BeTrue();
            
            arialDefault.Size.Should().Be(16);
            arialDefault.IsItalic.Should().BeFalse();
        }
        */

        /* Serializers
        [Fact]
        public void System_Text_Json_Can_Serialize_And_Deserialize_Records()
        {
            var serializedSettings = JsonSerializer.Serialize(ArialDefault);
            serializedSettings.Should().Be(@"{""Family"":""Arial"",""Size"":16}");

            var deserializedSettings = JsonSerializer.Deserialize<FontSettings>(serializedSettings);
            deserializedSettings.Should().Be(ArialDefault);
        }
        
        [Fact]
        public void Newtonsoft_Json_Can_Serialize_And_Deserialize_Records()
        {
            var serializedSettings = JsonConvert.SerializeObject(ArialDefault);
            serializedSettings.Should().Be(@"{""Family"":""Arial"",""Size"":16}");

            var deserializedSettings = JsonConvert.DeserializeObject<FontSettings>(serializedSettings);
            deserializedSettings.Should().Be(ArialDefault);
        }
        */
    }
}