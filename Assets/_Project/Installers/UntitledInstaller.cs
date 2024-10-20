using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] HintManager hintManager;
    public override void InstallBindings()
    {
        Container.Bind<HintManager>().FromInstance(hintManager).AsSingle();
    }
}