using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusGameSystems.Command
{
    public abstract class BaseCommand : BaseSO, ICommand
    {
        [Button, DisableInEditorMode]
        public abstract void Execute();

        [Button, DisableInEditorMode]
        public abstract void Undo();
    }
}