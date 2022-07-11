﻿#pragma warning disable 1591
namespace SharpPdb.Windows;

public enum RegisterId : ushort
{
    ERR = 30000,
    TEB = 30001,
    TIMER = 30002,
    EFAD1 = 30003,
    EFAD2 = 30004,
    EFAD3 = 30005,
    VFRAME = 30006,
    HANDLE = 30007,
    PARAMS = 30008,
    LOCALS = 30009,
    TID = 30010,
    ENV = 30011,
    CMDLN = 30012,

    NONE = 0,
    AL = 1,
    CL = 2,
    DL = 3,
    BL = 4,
    AH = 5,
    CH = 6,
    DH = 7,
    BH = 8,
    AX = 9,
    CX = 10,
    DX = 11,
    BX = 12,
    SP = 13,
    BP = 14,
    SI = 15,
    DI = 16,
    EAX = 17,
    ECX = 18,
    EDX = 19,
    EBX = 20,
    ESP = 21,
    EBP = 22,
    ESI = 23,
    EDI = 24,
    ES = 25,
    CS = 26,
    SS = 27,
    DS = 28,
    FS = 29,
    GS = 30,
    IP = 31,
    FLAGS = 32,
    EIP = 33,
    EFLAGS = 34,
    TEMP = 40,
    TEMPH = 41,
    QUOTE = 42,
    PCDR3 = 43,
    PCDR4 = 44,
    PCDR5 = 45,
    PCDR6 = 46,
    PCDR7 = 47,
    CR0 = 80,
    CR1 = 81,
    CR2 = 82,
    CR3 = 83,
    CR4 = 84,
    DR0 = 90,
    DR1 = 91,
    DR2 = 92,
    DR3 = 93,
    DR4 = 94,
    DR5 = 95,
    DR6 = 96,
    DR7 = 97,
    GDTR = 110,
    GDTL = 111,
    IDTR = 112,
    IDTL = 113,
    LDTR = 114,
    TR = 115,

    PSEUDO1 = 116,
    PSEUDO2 = 117,
    PSEUDO3 = 118,
    PSEUDO4 = 119,
    PSEUDO5 = 120,
    PSEUDO6 = 121,
    PSEUDO7 = 122,
    PSEUDO8 = 123,
    PSEUDO9 = 124,

    ST0 = 128,
    ST1 = 129,
    ST2 = 130,
    ST3 = 131,
    ST4 = 132,
    ST5 = 133,
    ST6 = 134,
    ST7 = 135,
    CTRL = 136,
    STAT = 137,
    TAG = 138,
    FPIP = 139,
    FPCS = 140,
    FPDO = 141,
    FPDS = 142,
    ISEM = 143,
    FPEIP = 144,
    FPEDO = 145,

    MM0 = 146,
    MM1 = 147,
    MM2 = 148,
    MM3 = 149,
    MM4 = 150,
    MM5 = 151,
    MM6 = 152,
    MM7 = 153,

    XMM0 = 154,
    XMM1 = 155,
    XMM2 = 156,
    XMM3 = 157,
    XMM4 = 158,
    XMM5 = 159,
    XMM6 = 160,
    XMM7 = 161,

    MXCSR = 211,

    EDXEAX = 212,

    EMM0L = 220,
    EMM1L = 221,
    EMM2L = 222,
    EMM3L = 223,
    EMM4L = 224,
    EMM5L = 225,
    EMM6L = 226,
    EMM7L = 227,

    EMM0H = 228,
    EMM1H = 229,
    EMM2H = 230,
    EMM3H = 231,
    EMM4H = 232,
    EMM5H = 233,
    EMM6H = 234,
    EMM7H = 235,

    MM00 = 236,
    MM01 = 237,
    MM10 = 238,
    MM11 = 239,
    MM20 = 240,
    MM21 = 241,
    MM30 = 242,
    MM31 = 243,
    MM40 = 244,
    MM41 = 245,
    MM50 = 246,
    MM51 = 247,
    MM60 = 248,
    MM61 = 249,
    MM70 = 250,
    MM71 = 251,

    BND0 = 396,
    BND1 = 397,
    BND2 = 398,


    XMM8 = 252,
    XMM9 = 253,
    XMM10 = 254,
    XMM11 = 255,
    XMM12 = 256,
    XMM13 = 257,
    XMM14 = 258,
    XMM15 = 259,


    SIL = 324,
    DIL = 325,
    BPL = 326,
    SPL = 327,

    RAX = 328,
    RBX = 329,
    RCX = 330,
    RDX = 331,
    RSI = 332,
    RDI = 333,
    RBP = 334,
    RSP = 335,

    R8 = 336,
    R9 = 337,
    R10 = 338,
    R11 = 339,
    R12 = 340,
    R13 = 341,
    R14 = 342,
    R15 = 343,

    R8B = 344,
    R9B = 345,
    R10B = 346,
    R11B = 347,
    R12B = 348,
    R13B = 349,
    R14B = 350,
    R15B = 351,

    R8W = 352,
    R9W = 353,
    R10W = 354,
    R11W = 355,
    R12W = 356,
    R13W = 357,
    R14W = 358,
    R15W = 359,

    R8D = 360,
    R9D = 361,
    R10D = 362,
    R11D = 363,
    R12D = 364,
    R13D = 365,
    R14D = 366,
    R15D = 367,


    AMD64_YMM0 = 368,
    AMD64_YMM1 = 369,
    AMD64_YMM2 = 370,
    AMD64_YMM3 = 371,
    AMD64_YMM4 = 372,
    AMD64_YMM5 = 373,
    AMD64_YMM6 = 374,
    AMD64_YMM7 = 375,
    AMD64_YMM8 = 376,
    AMD64_YMM9 = 377,
    AMD64_YMM10 = 378,
    AMD64_YMM11 = 379,
    AMD64_YMM12 = 380,
    AMD64_YMM13 = 381,
    AMD64_YMM14 = 382,
    AMD64_YMM15 = 383,

    AMD64_XMM16 = 694,
    AMD64_XMM17 = 695,
    AMD64_XMM18 = 696,
    AMD64_XMM19 = 697,
    AMD64_XMM20 = 698,
    AMD64_XMM21 = 699,
    AMD64_XMM22 = 700,
    AMD64_XMM23 = 701,
    AMD64_XMM24 = 702,
    AMD64_XMM25 = 703,
    AMD64_XMM26 = 704,
    AMD64_XMM27 = 705,
    AMD64_XMM28 = 706,
    AMD64_XMM29 = 707,
    AMD64_XMM30 = 708,
    AMD64_XMM31 = 709,

    AMD64_YMM16 = 710,
    AMD64_YMM17 = 711,
    AMD64_YMM18 = 712,
    AMD64_YMM19 = 713,
    AMD64_YMM20 = 714,
    AMD64_YMM21 = 715,
    AMD64_YMM22 = 716,
    AMD64_YMM23 = 717,
    AMD64_YMM24 = 718,
    AMD64_YMM25 = 719,
    AMD64_YMM26 = 720,
    AMD64_YMM27 = 721,
    AMD64_YMM28 = 722,
    AMD64_YMM29 = 723,
    AMD64_YMM30 = 724,
    AMD64_YMM31 = 725,

    AMD64_ZMM0 = 726,
    AMD64_ZMM1 = 727,
    AMD64_ZMM2 = 728,
    AMD64_ZMM3 = 729,
    AMD64_ZMM4 = 730,
    AMD64_ZMM5 = 731,
    AMD64_ZMM6 = 732,
    AMD64_ZMM7 = 733,
    AMD64_ZMM8 = 734,
    AMD64_ZMM9 = 735,
    AMD64_ZMM10 = 736,
    AMD64_ZMM11 = 737,
    AMD64_ZMM12 = 738,
    AMD64_ZMM13 = 739,
    AMD64_ZMM14 = 740,
    AMD64_ZMM15 = 741,
    AMD64_ZMM16 = 742,
    AMD64_ZMM17 = 743,
    AMD64_ZMM18 = 744,
    AMD64_ZMM19 = 745,
    AMD64_ZMM20 = 746,
    AMD64_ZMM21 = 747,
    AMD64_ZMM22 = 748,
    AMD64_ZMM23 = 749,
    AMD64_ZMM24 = 750,
    AMD64_ZMM25 = 751,
    AMD64_ZMM26 = 752,
    AMD64_ZMM27 = 753,
    AMD64_ZMM28 = 754,
    AMD64_ZMM29 = 755,
    AMD64_ZMM30 = 756,
    AMD64_ZMM31 = 757,

    AMD64_K0 = 758,
    AMD64_K1 = 759,
    AMD64_K2 = 760,
    AMD64_K3 = 761,
    AMD64_K4 = 762,
    AMD64_K5 = 763,
    AMD64_K6 = 764,
    AMD64_K7 = 765,
}
