//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from S:\github\labs-oop\MyExcel\MyExcel\LabCalculator.b4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MyExcel {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class LabCalculatorLexer : Lexer {
	public const int
		NUMBER=1, IDENTIFIER=2, INT=3, EXPONENT=4, SUBTRACT=5, ADD=6, MULTIPLY=7, 
		DIVIDE=8, DEC=9, INC=10, MMIN=11, MMAX=12, DESP=13, LPAREN=14, RPAREN=15, 
		WS=16;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"NUMBER", "IDENTIFIER", "INT", "EXPONENT", "SUBTRACT", "ADD", "MULTIPLY", 
		"DIVIDE", "DEC", "INC", "MMIN", "MMAX", "DESP", "LPAREN", "RPAREN", "WS"
	};


	public LabCalculatorLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, "'^'", "'-'", "'+'", "'*'", "'/'", "'DEC'", "'INC'", 
		"'MMIN'", "'MMAX'", "','", "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "NUMBER", "IDENTIFIER", "INT", "EXPONENT", "SUBTRACT", "ADD", "MULTIPLY", 
		"DIVIDE", "DEC", "INC", "MMIN", "MMAX", "DESP", "LPAREN", "RPAREN", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "LabCalculator.b4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x12^\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x3\x2\x3\x2\x3\x2\x5\x2\'\n\x2\x3\x3\x6\x3*\n\x3\r"+
		"\x3\xE\x3+\x3\x3\x3\x3\x6\x3\x30\n\x3\r\x3\xE\x3\x31\x3\x4\x6\x4\x35\n"+
		"\x4\r\x4\xE\x4\x36\x3\x5\x3\x5\x3\x6\x3\x6\x3\a\x3\a\x3\b\x3\b\x3\t\x3"+
		"\t\x3\n\x3\n\x3\n\x3\n\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3"+
		"\r\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3"+
		"\x11\x3\x11\x3\x11\x2\x2\x2\x12\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2"+
		"\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2"+
		"\xF\x1D\x2\x10\x1F\x2\x11!\x2\x12\x3\x2\x6\x4\x2\x43\\\x63|\x3\x2\x33"+
		";\x3\x2\x32;\x5\x2\v\f\xF\xF\"\"\x61\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2"+
		"\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2"+
		"\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2"+
		"\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D"+
		"\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x3#\x3\x2\x2\x2\x5)\x3"+
		"\x2\x2\x2\a\x34\x3\x2\x2\x2\t\x38\x3\x2\x2\x2\v:\x3\x2\x2\x2\r<\x3\x2"+
		"\x2\x2\xF>\x3\x2\x2\x2\x11@\x3\x2\x2\x2\x13\x42\x3\x2\x2\x2\x15\x46\x3"+
		"\x2\x2\x2\x17J\x3\x2\x2\x2\x19O\x3\x2\x2\x2\x1BT\x3\x2\x2\x2\x1DV\x3\x2"+
		"\x2\x2\x1FX\x3\x2\x2\x2!Z\x3\x2\x2\x2#&\x5\a\x4\x2$%\a\x30\x2\x2%\'\x5"+
		"\a\x4\x2&$\x3\x2\x2\x2&\'\x3\x2\x2\x2\'\x4\x3\x2\x2\x2(*\t\x2\x2\x2)("+
		"\x3\x2\x2\x2*+\x3\x2\x2\x2+)\x3\x2\x2\x2+,\x3\x2\x2\x2,-\x3\x2\x2\x2-"+
		"/\t\x3\x2\x2.\x30\t\x4\x2\x2/.\x3\x2\x2\x2\x30\x31\x3\x2\x2\x2\x31/\x3"+
		"\x2\x2\x2\x31\x32\x3\x2\x2\x2\x32\x6\x3\x2\x2\x2\x33\x35\x4\x32;\x2\x34"+
		"\x33\x3\x2\x2\x2\x35\x36\x3\x2\x2\x2\x36\x34\x3\x2\x2\x2\x36\x37\x3\x2"+
		"\x2\x2\x37\b\x3\x2\x2\x2\x38\x39\a`\x2\x2\x39\n\x3\x2\x2\x2:;\a/\x2\x2"+
		";\f\x3\x2\x2\x2<=\a-\x2\x2=\xE\x3\x2\x2\x2>?\a,\x2\x2?\x10\x3\x2\x2\x2"+
		"@\x41\a\x31\x2\x2\x41\x12\x3\x2\x2\x2\x42\x43\a\x46\x2\x2\x43\x44\aG\x2"+
		"\x2\x44\x45\a\x45\x2\x2\x45\x14\x3\x2\x2\x2\x46G\aK\x2\x2GH\aP\x2\x2H"+
		"I\a\x45\x2\x2I\x16\x3\x2\x2\x2JK\aO\x2\x2KL\aO\x2\x2LM\aK\x2\x2MN\aP\x2"+
		"\x2N\x18\x3\x2\x2\x2OP\aO\x2\x2PQ\aO\x2\x2QR\a\x43\x2\x2RS\aZ\x2\x2S\x1A"+
		"\x3\x2\x2\x2TU\a.\x2\x2U\x1C\x3\x2\x2\x2VW\a*\x2\x2W\x1E\x3\x2\x2\x2X"+
		"Y\a+\x2\x2Y \x3\x2\x2\x2Z[\t\x5\x2\x2[\\\x3\x2\x2\x2\\]\b\x11\x2\x2]\""+
		"\x3\x2\x2\x2\a\x2&+\x31\x36\x3\x2\x3\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace MyExcel
