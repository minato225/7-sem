.CODE

MySegment SEGMENT READ WRITE EXECUTE
ChangeOp PROC
	MOV EAX, ECX					; ����������� �������� ������� � EAX
	MOV DWORD PTR Op, 9005e883h		; ������ �������� �� ���������

	Op:								; ������ ����� ��������
		ADD EAX, 5					; ��������� � ��������� 5
		NOP							; ������ ��������
		RET							; ��������� �������
ChangeOp ENDP
MySegment ENDS
END








;.CODE
;
;MySegment SEGMENT READ WRITE EXECUTE
;
;ChangeOp PROC
;	MOV EAX, ECX ; ����������� �������� � eax
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