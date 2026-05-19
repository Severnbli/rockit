namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization
{
    public static class LocalizationEntriesContracts
    {
        public const string Play = "play";
        public const string LanguageNameS = "language_name_s";
        public const string LanguageNameV = "language_name_v";
        public const string LoadingS = "loading_s";
        public const string Collection = "collection";
    
        public static class Const
        {
            public const string S = "const_s";
            public const string V = "const_v";
            public const string UndefinedInfo = "const_undefined_info";
            public const string InvestigatedInfo = "const_investigated_info";
            public const string WithNameS = "const_with_name_s";
            public const string WithNameV = "const_with_name_v";
            public const string DiscovererInfo = "const_discoverer_info";
            public const string CurrValue = "const_curr_value";
            public const string CurrValueIsMax = "const_curr_value_is_max";
            public const string ImproveInfo = "const_improve_info";
            public const string Improve = "const_improve";
        
            public static class Speed
            {
                public const string Name = "const_speed_name";
                public const string Discoverer = "const_speed_discoverer";
                public const string Info = "const_speed_info";
            }
        
            public static class Flights
            {
                public const string Name = "const_flights_name";
                public const string Discoverer = "const_flights_discoverer";
                public const string Info = "const_flights_info";
            }
        
            public static class Dashes
            {
                public const string Name = "const_dashes_name";
                public const string Discoverer = "const_dashes_discoverer";
                public const string Info = "const_dashes_info";
            }
        
            public static class Multi
            {
                public const string Name = "const_multi_name";
                public const string Discoverer = "const_multi_discoverer";
                public const string Info = "const_multi_info";
            }
        }

        public static class Controls
        {
            public static string Separator = " – ";
            
            public static class Run
            {
                public static string Control = "controls_run";
                public static string Info = "controls_run_info";
            }

            public static class Jump
            {
                public static string Control = "controls_jump";
                public static string Info = "controls_jump_info";
            }

            public static class Dash
            {
                public static string Control = "controls_dash";
                public static string Info = "controls_dash_info";
            }

            public static class Platforms
            {
                public static class Position
                {
                    public static string Control = "controls_platforms_position";
                    public static string Info = "controls_platforms_position_info";
                }

                public static class Rotation
                {
                    public  static string Control = "controls_platforms_rotation";
                    public static string Info = "controls_platforms_rotation_info";
                }

                public static class Scale
                {
                    public static string Control = "controls_platforms_scale";
                    public static string Info = "controls_platforms_scale_info";
                }
            }
        }
    }
}