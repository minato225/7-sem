org 100h

section .text
    mov ax, section..data.start
    mov ds, ax
    mov ax, stack
    mov ss, ax
    mov sp, ax

    mov ax, 0
    mov ah, 0ah
    lea dx, [buffer]
    int 21h

    push    cx
    pop     cx
;     mov cl, [buffer]
;     mov bx, 0
; readnum:
;     add bx, 1
;     mov ax, [buffer + bx]
;     mov dl, 10
;     push cx
; mul10:
;     mul dl
;     loop mul10
;     pop cx
;     loop readnum

    mov ah, 4ch
    int 21h

section .data
    buffer times 10 db 0
    db '$'

stack:
    times 10 db 0