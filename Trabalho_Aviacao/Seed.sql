USE AVIACAO;

-- CLIENTES
INSERT INTO CLIENTE (NOME, CONTATO, GENERO, DATA_NASCIMENTO) 
VALUES ('Kati Outinen', 'kati-outinen@gmail.com', 'Feminino', 19610817),
	   ('Bjork Gudmundsdóttir', 'bjork56gudmunds@gmail.com', 'Feminino', 19651121),
       ('José Igor Monteiro', 'jose.monteiro6@gmail.com', 'Masculino', 20010131),
       ('Fábio Pereira', 'fabio.pereira@gmail.com', 'Masculino', 19990610),
       ('Charles Leclerc', 'leclercharles123@gmail.com', 'Masculino', 19971016),
       ('Hatsune Miku', 'hatsune.miku@gmail.com', 'Feminino', 20070831),
       ('Katsushika Hokusai', 'katsushika.hokusai@gmail.com', 'Masculino', 19200511),
       ('Jemison van der Graaff', 'jemisongraaff44@gmail.com', 'Masculino', 19350918),
       ('Teresa de Jesus', 'teresa.jesus@gmail.com', 'Feminino', 20051221),
       ('Tatiane Espíndola', 'tatiane.espindola9@gmail.com', 'Feminino', 19540311),
       ('Mariana das Chagas', 'mariana.chagas@gmail.com', 'Feminino', 20020417),
       ('Isabela Ferreira', 'isabela-ra12@gmail.com', 'Feminino', 20030303),
       ('Juliana Santos', 'juliana567@gmail.com', 'Feminino', 20040404);

-- AEROPORTO
INSERT INTO AEROPORTO(LOCALIZACAO) 
VALUES ('Guarulhos'),
       ('Fortaleza'),
       ('Natal'), 
       ('Helsinki'), 
       ('Amsterdã'), 
       ('Paris'),
       ('Reykjavik'), 
       ('Doha'),
       ('Osaka'),
       ('Videira'),
       ('Florianópolis'),
       ('Lisboa'),
       ('Dallas'),
       ('Toronto'),
       ('Melbourne');

-- AERONAVES 
INSERT INTO TIPO_AERONAVE(DESCRICAO)
VALUES ('Boeing 777'),
	   ('Airbus 350');
       
INSERT INTO AERONAVE (QTD_POLTRONAS, ID_TIPO_AERONAVE) 
VALUES (450, 1),
	   (320, 1),
       (280, 2),
       (300, 2),
       (350, 2);
       
-- VOOS
INSERT INTO VOO (HORARIO_SAIDA, HORARIO_DESTINO, ID_AEROPORTO_SAIDA, ID_AEROPORTO_DESTINO, ID_AERONAVE)
VALUES (20240415223000, 20240416033000, 10, 11, 1),
	   (20240423081500, 20240425054500, 1, 4, 1),
       (20241128073000, 20241130031500, 1, 7, 5),
       (20241214153000, 20241216185000, 1, 9, 1),
       (20241219052000, 20241219113000, 3, 1, 3),
       (20240412102000, 20240414174500, 12, 9, 2),
       (20240425153000, 20240427064500, 13, 15, 2),
       (20241102075000, 20241102223000, 14, 5, 4);

-- HORÁRIOS
-- Ver arquivo Trigger_Insert_Horarios.sql

-- ESCALAS
INSERT INTO ESCALA (HORARIO_SAIDA, ID_VOO, ID_AEROPORTO_SAIDA)
VALUES (20240424123000, 2, 5),
	   (20241129023000, 3, 6),
       (20241215101500, 4, 8),
       (20241219091500, 5, 2),
       (20240413082000, 6, 5),
       (20240426122500, 7, 15),
       (20241102144500, 8, 7);

-- COMPRAS DE HORÁRIOS
INSERT INTO COMPRA(ID_HORARIO, ID_CLIENTE)
VALUES (147, 1),
	   (368, 2),
       (228, 3),
       (1609, 4),
       (1310, 5),
       (2210, 6),
       (776, 7),
       (698, 8),
       (59, 9),
       (765, 10),
       (9, 11),
       (1285, 12),
       (1357, 13);