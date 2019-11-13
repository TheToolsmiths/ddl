# ddl

Data Definition Language for Game Development Tools

ddl is a DSL for describing data structures, but unlike using programming languages (like C, C++, C#), it can be parsed more efficiently.

It can be used for:
* data-driven type systems, where data structures are completely decoupled from compilation
* code generation systems, where code is generated from the DSL and compiled into a program
* hybrid systems where some types are data-driven and others are coupled

## Contributing

### Setup Visual Studio Code Remote development

Currently the development workflow requires use of Visual Studio Code Remote Containers feature.
More info can be found [here](https://code.visualstudio.com/docs/remote/containers).
After following the install instructions, use the `Remote-Containers: Reopen in containers` command.

### Build C# Parser files

**NOTE**: This step is required everytime there is a change to the grammar file in `spec/Ddl.g4`

Still with VSCode open remotely on the remote container, open a terminal window and execute
```
/scripts/vsremote/build_csharp_files.sh
```

This will generate the required C# files in `artifacts/antlr-csharp/Ddl*.cs`.

### Open the Visual Studio Solution

After successfully generating the C# files, open locally the Visual Studio solution `src\Ddl.Parser\Ddl.Parser.sln` with Visual Studio or Visual Studio Code.

Currently the remote development docker image does not contain a .Net Core SDK, so won't be possible to build and test the solution in the remote container.
