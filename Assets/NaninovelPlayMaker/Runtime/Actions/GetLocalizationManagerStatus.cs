﻿using HutongGames.PlayMaker;

namespace Naninovel.PlayMaker
{
    [ActionCategory("Naninovel")]
    public class GetLocalizationManagerStatus : FsmStateAction
    {
        [Tooltip("Whether the game is currently running under the source locale.")]
        [UIHint(UIHint.Variable)]
        public FsmBool SourceLocaleSelected;

        [UIHint(UIHint.Variable)]
        public FsmString SourceLocale;

        [UIHint(UIHint.Variable)]
        public FsmString SelectedLocale;

        public override void Reset ()
        {
            SourceLocaleSelected = null;
            SourceLocale = null;
            SelectedLocale = null;
        }

        public override void OnEnter ()
        {
            var localizationManager = Engine.GetService<LocalizationManager>();
            if (localizationManager is null) { Finish(); return; }

            SourceLocaleSelected.Value = localizationManager.SourceLocaleSelected();
            SourceLocale.Value = Configuration.LoadOrDefault<LocalizationConfiguration>().SourceLocale;
            SelectedLocale.Value = localizationManager.SelectedLocale;

            Finish();
        }
    }
}
