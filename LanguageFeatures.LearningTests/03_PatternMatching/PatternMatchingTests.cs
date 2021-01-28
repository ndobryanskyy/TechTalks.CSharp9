using FluentAssertions;
using Xunit;

namespace LanguageFeatures.LearningTests
{
    public sealed class PatternMatchingTests
    {
        public record IdeFontSettings(
            FontSettings DefaultFont,
            FontSettings? UserDefaultFont = default,
            FontSettings? ProjectFont = default);
        
        [Fact]
        public void Should_Support_Pattern_Negation_With_NOT()
        {
            var settings = new IdeFontSettings(DefaultFonts.Consolas, DefaultFonts.FiraCode);

            // ! && || not and or is
            var userFontIsSet = settings.UserDefaultFont is not null;
            userFontIsSet.Should().BeTrue();

            var nonDefaultSize = settings.UserDefaultFont!.Size is not 16;
            nonDefaultSize.Should().BeTrue();
        }

        [Fact]
        public void Support_Not_Null_Expression_In_Switch()
        {
            static FontSettings GetEffectiveFont(IdeFontSettings? settings) => settings switch
            {
                { ProjectFont: { } projectFont } => projectFont,
                { UserDefaultFont: var userFont and not null } => userFont,
                not null => settings.DefaultFont,
                null => DefaultFonts.Consolas
            };
            
            var defaultSettings = new IdeFontSettings(DefaultFonts.Consolas);
            var withUserDefault = defaultSettings with { UserDefaultFont = DefaultFonts.Arial };
            var withUserDefaultAndProject = withUserDefault with { ProjectFont = DefaultFonts.FiraCode };

            GetEffectiveFont(defaultSettings).Should().Be(DefaultFonts.Consolas);
            GetEffectiveFont(withUserDefault).Should().Be(DefaultFonts.Arial);
            GetEffectiveFont(withUserDefaultAndProject).Should().Be(DefaultFonts.FiraCode);
            
            GetEffectiveFont(null).Should().Be(DefaultFonts.Consolas);
        }

        [Fact]
        public void Support_And_Or_Patterns()
        {
            static bool IsNiceFont(FontSettings settings)
                => settings is ExtendedFontSettings and 
                    ({ IsItalic: true } or
                    { Family: "Fira Code" or "Consolas", Size: >= 14 and <= 24 });

            var italicArial = new ExtendedFontSettings("Arial", 30, true);
            var consolas14 = new ExtendedFontSettings("Consolas", 14);
            var firaCode24 = new ExtendedFontSettings("Fira Code", 24);
            var firaCode30 = firaCode24 with { Size = 30 };
            
            IsNiceFont(DefaultFonts.FiraCode).Should().BeFalse();
            IsNiceFont(firaCode30).Should().BeFalse();
            
            IsNiceFont(italicArial).Should().BeTrue();
            IsNiceFont(firaCode24).Should().BeTrue();
            IsNiceFont(consolas14).Should().BeTrue();
        }
    }
}