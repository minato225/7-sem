.CODE

MySegment SEGMENT READ WRITE EXECUTE
ChangeOp PROC
	MOV EAX, ECX					; Переместить параметр функции в EAX
	MOV DWORD PTR Op, 9005e883h		; замена операции на вычитание

	Op:								; макрас нашей операции
		ADD EAX, 5					; прибавить к параметру 5
		NOP							; пустая операция
		RET							; завершить функцию
ChangeOp ENDP
MySegment ENDS
END








;.CODE
;
;MySegment SEGMENT READ WRITE EXECUTE
;
;ChangeOp PROC
;	MOV EAX, ECX ; Переместить параметр в eax
;	MOV DWORD PTR Op, 9005e883h
;
;Op:
;	ADD EAX, 5
;	NOP
;	RET
;
;ChangeOp ENDP
;MySegment ENDS
;END