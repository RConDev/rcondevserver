namespace RConDevServer.Protocol.Dice.Battlefield3.Injection
{
    using Command;
    using CommandFactory;
    using CommandFactory.Admin;
    using Ninject.Modules;

    public class CommandFactoryModule : NinjectModule 
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ICommandFactory<ICommand>>().To<KickPlayerCommandFactory>().Named(CommandNames.AdminKickPlayer);
        }
    }
}
