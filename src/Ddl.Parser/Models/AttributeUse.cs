namespace TheToolsmiths.Ddl.Parser.Models
{
    public abstract class BaseAttributeUse : IAttributeUse
    {
        public abstract AttributeUseType UseType { get; }
        public abstract bool IsKeyed { get; }
        public abstract bool IsTyped { get; }
    }

    public abstract class BaseTypedAttributeUse : BaseAttributeUse, ITypedAttributeUse
    {
        protected BaseTypedAttributeUse(TypeIdentifier type, StructValueInitialization initialization)
        {
            Type = type;
            Initialization = initialization;
        }

        public TypeIdentifier Type { get; }

        public StructValueInitialization Initialization { get; }
    }

    public class KeyedLiteralAttributeUse : BaseAttributeUse, IKeyedLiteralAttributeUse
    {
        public KeyedLiteralAttributeUse(Identifier key, LiteralInitialization literal)
        {
            Key = key;
            Literal = literal;
        }

        public override AttributeUseType UseType => AttributeUseType.KeyedLiteral;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public Identifier Key { get; }

        public LiteralInitialization Literal { get; }
    }

    public class KeyedTypedAttributeUse : BaseTypedAttributeUse, IKeyedTypedAttributeUse
    {
        public KeyedTypedAttributeUse(Identifier key, TypeIdentifier type, StructValueInitialization initialization)
            : base(type, initialization)
        {
            Key = key;
        }

        public override AttributeUseType UseType => AttributeUseType.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public Identifier Key { get; }
    }

    public class TypedAttributeUse : BaseTypedAttributeUse, ITypedAttributeUse
    {
        public TypedAttributeUse(TypeIdentifier type, StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override AttributeUseType UseType => AttributeUseType.Typed;

        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }

    public interface IAttributeUse
    {
        AttributeUseType UseType { get; }

        bool IsKeyed { get; }

        bool IsTyped { get; }
    }

    public interface IKeyedAttributeUse : IAttributeUse
    {
        Identifier Key { get; }
    }

    public interface ITypedAttributeUse : IAttributeUse
    {
        TypeIdentifier Type { get; }

        StructValueInitialization Initialization { get; }
    }

    public interface IKeyedTypedAttributeUse : ITypedAttributeUse, IKeyedAttributeUse
    {
    }

    public interface IKeyedLiteralAttributeUse : IKeyedAttributeUse
    {
        LiteralInitialization Literal { get; }
    }

    public enum AttributeUseType
    {
        KeyedLiteral,
        KeyedTyped,
        Typed
    }
}
