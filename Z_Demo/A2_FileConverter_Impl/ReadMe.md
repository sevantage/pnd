# IoCC setup
This demo implementation uses Ninject as IoC framework. As this project is not very complex, a simple approach was chosen:

 - The only projects that hold a reference to Ninject are FileConverter ("the UI") and FileConverter.IoC. 
 - The latter references both business logic (BL) and data access (DA) and contains a module that registers the bindings for various types.
 - The UI decides which output to use (in our case always XML, but this could change later). It creates the builder not directly, but requests and instance from the IoC container. For now, this returns the type directly, but the configuration could be changed later on to provide a different type. 
 - In order to create an instance that implements IOrderReader, a factory is used that is provided by the IoCC. The factory contains code to instantiate the OrderTextReader class; as an alternative, it would be possible to add a factory method to the IoCC configuration, but implementing a dedicated factory makes the complex construction more obvious.  
 The instance of the factory is provided by the IoCC, so it is possible to provide a different factory if required at a later point in time.