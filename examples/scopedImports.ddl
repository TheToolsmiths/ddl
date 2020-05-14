/*********************
    Scoped imports

** --------------------------------**
Assume a folder structure as follows:

Root
└── Foo
    ├── FooStruct1.ddl
    ├── FooStruct2.ddl
    └── Bar
        ├── BarStruct1.ddl
        ├── BarStruct2.ddl
        └── Baz
            ├── BazStruct1.ddl
            └── BazStruct2.ddl
** --------------------------------**

**********************/

// 1. Places the Foo root namespace in scope
import ::Foo;

// 2. Places the FooStruct1 type in scope
import ::Foo::FooStruct1;

// 3. Places the group with FooStruct2 type in scope
import ::Foo::{ FooStruct2 };    

// 4. Places the FooStruct3 type in scope with alias
import ::Foo::FooStruct3 as AwesomeFooStruct;

// 5. Places the group with FooStruct4 type in scope with alias
import ::Foo::{ FooStruct4 as SuperFooStruct };

def struct ScopedStruct1 {
    // Uses type imported by (2)
    foo1: FooStruct1,

    // Uses type based on namespace imported by (1)
    foo2: Foo::FooStruct2,
    // Uses type imported by (3)
    foo3: FooStruct2,

    // Uses type based on root namespace
    foo4: ::Foo::FooStruct3,
    
    // Uses type based on alias introduced by (4)
    foo5: AwesomeFooStruct,

    // Uses type based on alias introduced by (5)
    foo6: SuperFooStruct,
}

scope {
    // 6. Places the CoolBaz alias as Foo namespace in scope, based on import (1)
    import Foo as CoolBaz;
    
    // 7. Places the CoolBaz alias as Foo::Bar root namespace in scope
    import ::Foo::Bar as UncoolBaz;

    // 6. Places the Foo::Bar root namespace in scope
    import ::Foo::Bar;        
    // 7. Places the Foo::Bar namespace in scope, based on import (1)
    import Foo::Bar;
    // 8. Places the BarStruct1 type in scope, based on import (1)
    import Foo::Bar::BarStruct1;
    // 9. Places the BarStruct2 type in scope, based on root namespace
    import ::Foo::Bar::BarStruct2;
    // 10. Places the BarStruct3 type in scope with alias, based on import (1)
    import Foo::Bar::BarStruct3 as FantasticBarStruct;
    // 11. Places the BarStruct4 type in scope with alias, based on root namespace
    import ::Foo::Bar::BarStruct4 as MegaBarStruct;

    def struct ScopedStruct2 {
        bar1: BarStruct1,
        bar2: Bar::FooStruct2,
        bar2: Foo::FooStruct2,
        bar2: Foo::Bar::FooStruct2,
        bar3: ::Foo::Bar::FooStruct3,
        bar4: FantasticBarStruct,
        bar5: MegaBarStruct,
    }        

    def struct ScopedStruct3 {
        // Uses type imported by (2)
        foo1: FooStruct1,

        // Uses type based on namespace imported by (1)
        foo2: Foo::FooStruct5,

        // Uses type imported by (3)
        foo3: FooStruct2,

        // Uses type based on root namespace
        foo4: ::Foo::FooStruct6,
        
        // Uses type based on alias introduced by (4)
        foo5: AwesomeFooStruct,

        // Uses type based on alias introduced by (5)
        foo6: SuperFooStruct,

        // Uses type based on aliased namespace imported by (1)
        foo2: CoolBaz::FooStruct7,
    }
}

scope {
    def struct ScopedStruct4 {
        // Uses type imported by (2)
        foo1: FooStruct1,

        // Uses type based on namespace imported by (1)
        foo2: Foo::FooStruct2,
        // Uses type imported by (3)
        foo3: FooStruct2,

        // Uses type based on root namespace
        foo4: ::Foo::FooStruct3,
        
        // Uses type based on alias introduced by (4)
        foo5: AwesomeFooStruct,

        // Uses type based on alias introduced by (5)
        foo6: SuperFooStruct,
    }
}