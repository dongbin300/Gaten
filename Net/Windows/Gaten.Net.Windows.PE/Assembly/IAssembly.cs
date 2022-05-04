using Gaten.Net.Extension;

namespace Gaten.Net.Windows.PE.Assembly
{
    public enum OpcodeType : byte
    {
        AAA,
        AAD,
        AAM,
        AAS,
        ADC,
        ADD,
        ADDR16,
        AND,
        ARPL,
        BOUND,
        BSWAP,
        CALL,
        CDQ,
        CLC,
        CLD,
        CLI,
        CMC,
        CMP,
        CMPS,
        CS,
        CWDE,
        DAA,
        DAS,
        DATA16,
        DEC,
        DIV,
        DS,
        ES,
        FADD,
        FBLD,
        FBSTP,
        FCOM,
        FCOMP,
        FDIV,
        FDIVR,
        FIADD,
        FICOM,
        FICOMP,
        FIDIV,
        FIDIVR,
        FILD,
        FIMUL,
        FIST,
        FISTP,
        FISTTP,
        FISUB,
        FISUBR,
        FLD,
        FLDCW,
        FLDENV,
        FMUL,
        FNSTCW,
        FNSTENV,
        FS,
        FST,
        FSTP,
        FSUB,
        FSUBR,
        FWAIT,
        GS,
        HLT,
        ICEBP,
        IDIV,
        IMUL,
        IN,
        INC,
        INS,
        INSB,
        INSD,
        INT,
        INT1,
        INT3,
        INTO,
        IRET,
        IRETD,
        JA,
        JAE,
        JB,
        JBE,
        JE,
        JECXZ,
        JG,
        JGE,
        JL,
        JLE,
        JMP,
        JNE,
        JNO,
        JNP,
        JNS,
        JO,
        JP,
        JS,
        LAHF,
        LDS,
        LEA,
        LEAVE,
        LES,
        LOCK,
        LODS,
        LODSB,
        LODSD,
        LOOP,
        LOOPE,
        LOOPNE,
        MOV,
        MOVS,
        MOVSB,
        MOVSD,
        MUL,
        NEG,
        NOP,
        NOT,
        OR,
        OUT,
        OUTS,
        OUTSB,
        OUTSD,
        POP,
        POPA,
        POPAD,
        POPF,
        POPFD,
        PUSH,
        PUSHA,
        PUSHAD,
        PUSHF,
        PUSHFD,
        REPNZ,
        REPZ,
        RET,
        RETF,
        RETFAR,
        RCL,
        RCR,
        ROL,
        ROR,
        SAHF,
        SBB,
        SCAS,
        SCASB,
        SCASD,
        SHL,
        SHR,
        SS,
        STC,
        STD,
        STI,
        STOS,
        STOSB,
        STOSD,
        SUB,
        TEST,
        XCHG,
        XLAT,
        XOR
    }

    public enum DataType
    {
        BYTE,
        WORD,
        DWORD,
        QWORD
    }

    /// <summary>
    /// AL
    /// CL
    /// DL
    /// BL
    /// ...
    /// </summary>
    public enum R8 : byte
    {
        AL,
        CL,
        DL,
        BL,
        AH,
        CH,
        DH,
        BH
    }

    /// <summary>
    /// AX
    /// CX
    /// DX
    /// BX
    /// ...
    /// </summary>
    public enum R16 : byte
    {
        AX,
        CX,
        DX,
        BX,
        SP,
        BP,
        SI,
        DI
    }

    /// <summary>
    /// EAX
    /// ECX
    /// EDX
    /// EBX
    /// ...
    /// </summary>
    public enum R32 : byte
    {
        EAX,
        ECX,
        EDX,
        EBX,
        ESP,
        EBP,
        ESI,
        EDI
    }

    /// <summary>
    /// RAX
    /// RCX
    /// RDX
    /// RBX
    /// ...
    /// </summary>
    public enum R64 : byte
    {
        RAX,
        RCX,
        RDX,
        RBX,
        RSP,
        RBP,
        RSI,
        RDI
    }

    /// <summary>
    /// ES
    /// CS
    /// SS
    /// DS
    /// ...
    /// </summary>
    public enum S : byte
    {
        ES,
        CS,
        SS,
        DS,
        FS,
        GS
    }

    /// <summary>
    /// BYTE[EAX]
    /// BYTE[ECX]
    /// BYTE[EDX]
    /// BYTE[EBX]
    /// ...
    /// </summary>
    public enum PTR8 : byte
    {
        EAX,
        ECX,
        EDX,
        EBX,
        ESP,
        EBP,
        ESI,
        EDI
    }

    /// <summary>
    /// WORD[EAX]
    /// WORD[ECX]
    /// WORD[EDX]
    /// WORD[EBX]
    /// ...
    /// </summary>
    public enum PTR16 : byte
    {
        EAX,
        ECX,
        EDX,
        EBX,
        ESP,
        EBP,
        ESI,
        EDI
    }

    /// <summary>
    /// DWORD[EAX]
    /// DWORD[ECX]
    /// DWORD[EDX]
    /// DWORD[EBX]
    /// ...
    /// </summary>
    public enum PTR32 : byte
    {
        EAX,
        ECX,
        EDX,
        EBX,
        ESP,
        EBP,
        ESI,
        EDI
    }

    /// <summary>
    /// FWORD[EAX]
    /// FWORD[ECX]
    /// FWORD[EDX]
    /// FWORD[EBX]
    /// ...
    /// </summary>
    public enum PTR48 : byte
    {
        EAX,
        ECX,
        EDX,
        EBX,
        ESP,
        EBP,
        ESI,
        EDI
    }

    /// <summary>
    /// QWORD[EAX]
    /// QWORD[ECX]
    /// QWORD[EDX]
    /// QWORD[EBX]
    /// ...
    /// </summary>
    public enum PTR64 : byte
    {
        EAX,
        ECX,
        EDX,
        EBX,
        ESP,
        EBP,
        ESI,
        EDI
    }

    public interface IAssembly
    {
        /// <summary>
        /// loop:
        ///     ...
        ///     ...
        ///     ...
        /// </summary>
        const string SITE_TOKEN = ":";

        /// <summary>
        /// PRCD loop
        ///     ...
        ///     ...
        ///     ...
        /// PRCD END
        /// </summary>
        const string PROCEDURE_KEYWORD = "PRCD";

        /// <summary>
        /// PRCD loop
        ///     ...
        ///     ...
        ///     ...
        /// PRCD END
        /// </summary>
        const string PROCEDURE_END_KEYWORD = "END";

        /// <summary>
        /// Entry Procedure Name
        /// </summary>
        const string ENTRY_PROCEDURE_NAME = "MAIN";

        /// <summary>
        /// PRCD main ; This is main procedure.
        /// </summary>
        const string COMMENT_TOKEN = ";";
    }
}
