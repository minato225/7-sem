; Sample x64 Assembly Program 

extern MessageBoxA

global showreg

section  .data
digits:   db     "0123456789ABCDEF"
title: db "Values", 0
regrax: db     "RAX",9,"........",10,13
regrbx: db     "RBX",9,"........",10,13
regrcx: db     "RCX",9,"........",10,13
regrdx: db     "RDX",9,"........",10,13
regrsp: db     "RSP",9,"........",10,13
regrbp: db     "RBP",9,"........",10,13
regrsi: db     "RSI",9,"........",10,13
regrdi: db     "RDI",9,"........",10,13
regr8:  db      "R8",9,"........",10,13
regr9:  db      "R9",9,"........",10,13
regr10: db     "R10",9,"........",10,13
regr11: db     "R11",9,"........",10,13
regr12: db     "R12",9,"........",10,13
regr13: db     "R13",9,"........",10,13
regr14: db     "R14",9,"........",10,13
regr15: db     "R15",9,"........",10,13,0

section  .text
showreg:
        push    rbp
        mov     rbp, rsp

        push    rax
        push    rbx
        push    rcx
        push    rdx
        push    r8
        push    r9
        push    r10
        push    r11
        push    r12
        push    r13
        push    r14
        push    r15
        push    r8

        push    rax
        lea     r8, [rel regrax + 3]
        call    print_hex
        pop     rax

        xchg    rax, rbx
        lea     r8, [rel regrbx + 3]
        call    print_hex
        xchg    rax, rbx

        xchg    rax, rcx
        lea     r8, [rel regrcx + 3]
        call    print_hex
        xchg    rax, rcx

        xchg    rax, rdx
        lea     r8, [rel regrdx + 3]
        call    print_hex
        xchg    rax, rdx

        push    rax
        mov     rax, rsp
        lea     r8, [rel regrsp + 3]
        call    print_hex
        pop     rax

        push    rax
        mov     rax, rbp
        lea     r8, [rel regrbp + 3]
        call    print_hex
        pop     rax

        push    rax
        mov     rax, rsi
        lea     r8, [rel regrsi + 3]
        call    print_hex
        pop     rax

        push    rax
        mov     rax, rdi
        lea     r8, [rel regrdi + 3]
        call    print_hex
        pop     rax

        pop     r8
        xchg    rax, r8
        lea     r8, [rel regr8 + 2]
        call    print_hex
        xchg    rax, r8
        
        xchg    rax, r9
        lea     r8, [rel regr9 + 2]
        call    print_hex
        xchg    rax, r9

        xchg    rax, r10
        lea     r8, [rel regr10 + 3]
        call    print_hex
        xchg    rax, r10

        xchg    rax, r11
        lea     r8, [rel regr11 + 3]
        call    print_hex
        xchg    rax, r11

        xchg    rax, r12
        lea     r8, [rel regr12 + 3]
        call    print_hex
        xchg    rax, r12

        xchg    rax, r13
        lea     r8, [rel regr13 + 3]
        call    print_hex
        xchg    rax, r13

        xchg    rax, r14
        lea     r8, [rel regr14 + 3]
        call    print_hex
        xchg    rax, r14

        xchg    rax, r15
        lea     r8, [rel regr15 + 3]
        call    print_hex
        xchg    rax, r15

        mov     rcx, 0
        lea     rdx, [rel regrax]
        lea     r8, [rel title]
        mov     r9d, 0
        call    MessageBoxA

        pop     r15
        pop     r14
        pop     r13
        pop     r12
        pop     r11
        pop     r10
        pop     r9
        pop     r8
        pop     rdx
        pop     rcx
        pop     rbx
        pop     rax

        jmp     return

print_hex: 
        push    rbp
        mov     rbp, rsp

        push    rbx
        push    rcx
        push    rdx
        mov     rcx, 8
loop:
        mov     rbx, rax
        and     rbx, 0xF

        mov     rdx, digits
        add     rdx, rbx
        mov     rdx, [rdx]

        mov     rbx, r8
        add     rbx, rcx
        mov     byte [rel rbx], dl

        shr     rax, 4
        loop    loop

        pop     rdx
        pop     rcx
        pop     rbx

        jmp     return

return:
        mov   rsp, rbp
        pop   rbp
        ret
