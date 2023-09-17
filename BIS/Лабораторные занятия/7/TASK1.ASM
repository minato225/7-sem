.model small
.data
  OblVvoda  db  15,?,15 dup (?)
  newline db 10, 13, '$'
  regcs db 'CS: $'
  regss db 'SS: $'
  reges db 'ES: $'
  regds db 'DS: $'   
  regsp db 'SP: $' 
  regbp db 'BP: $'
  regdi db 'DI: $'
  regsi db 'SI: $'
.code

print_word proc near
  push  ax

  xchg  al, ah
  call  print_byte
  xchg  al, ah
  call  print_byte

  pop  ax
  ret
  print_word endp

print_byte proc near
  push  ax
  push  bx
  mov  ah, 0
  mov  bl, 16
  div  bl

  call  print_4bit
  mov  al, ah
  call  print_4bit

  pop  bx
  pop  ax
  ret
  print_byte endp

print_4bit  proc near
  push  ax
  push  dx
  cmp  al, 10
  jge  letter  
  mov  dl, '0'
  jmp  print
letter:
  sub  al, 10
  mov  dl, 'A'
print:
  add  dl, al
  mov  ah, 02h
  int  21h
  pop  dx
  pop  ax
  ret
  print_4bit endp


UU:
  mov   ax, @data
  mov  ds,ax
  mov ah, 09h
  lea dx, newline
  int 21h
  mov ah, 09h ;-------- часть с выводом зачения регистра
  lea dx, regcs
  int 21h
  mov ax, cs
  call print_word ; -------
  mov ah, 09h 
  lea dx, newline
  int 21h

  mov ah, 09h 
  lea dx, regss
  int 21h
  mov ax, ss
  call print_word 
  mov ah, 09h
  lea dx, newline
  int 21h

  mov ah, 09h 
  lea dx, reges
  int 21h
  mov ax, es
  call print_word 
  mov ah, 09h
  lea dx, newline
  int 21h

  mov ah, 09h 
  lea dx, regds
  int 21h
  mov ax, ds
  call print_word 
  mov ah, 09h
  lea dx, newline
  int 21h

  mov ah, 09h 
  lea dx, regsp
  int 21h
  mov ax, sp
  call print_word 
  mov ah, 09h
  lea dx, newline
  int 21h

  mov ah, 09h 
  lea dx, regbp
  int 21h
  mov ax, bp
  call print_word 
  mov ah, 09h
  lea dx, newline
  int 21h

  mov ah, 09h 
  lea dx, regdi
  int 21h
  mov ax, di
  call print_word 
  mov ah, 09h
  lea dx, newline
  int 21h

  mov ah, 09h 
  lea dx, regsi
  int 21h
  mov ax, si
  call print_word 
  mov ah, 09h
  lea dx, newline
  int 21h

  mov  ah,10
  lea  dx,OblVvoda
  int  21h
  mov  OblVvoda+12,'P'
  mov  OblVvoda+14,'P'
  mov   ah,9
  lea  DX,OblVvoda+2
  mov  OblVvoda+16,'$'
  int  21h

  mov  ah,4ch
  int  21h

  end   UU
