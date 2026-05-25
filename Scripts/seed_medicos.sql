-- =============================================================================
-- CLINICAINOVA – Seed dos 2 profissionais de saúde (projeto original)
-- Banco: Inova (ajuste USE abaixo se o nome do schema for diferente)
-- Login: roberto@inova.pt / amanda@inova.pt  |  Senha: 123456
-- =============================================================================

USE `Inova`;

-- Evita erro se o script for executado mais de uma vez
DELETE FROM `Usuarios` WHERE `Id` IN (101, 102);

INSERT INTO `Usuarios` (
    `Id`,
    `Nome`,
    `Email`,
    `Senha`,
    `Perfil`,
    `Cpf`,
    `Telefone`,
    `DataNascimento`,
    `Discriminator`,
    `Especialidade`
) VALUES
(
    101,
    'Dr. Roberto Mendes',
    'roberto@inova.pt',
    '123456',
    'Profissional',
    '34587633894',
    '1192347258',
    '1980-01-01 00:00:00.000000',
    'ProfissionalSaude',
    'Multiespecialista'
),
(
    102,
    'Dra. Amanda Silva',
    'amanda@inova.pt',
    '123456',
    'Profissional',
    '98765432100',
    '11987654321',
    '1985-05-15 00:00:00.000000',
    'ProfissionalSaude',
    'Multiespecialista'
);

-- Próximo Id gerado automaticamente não colide com 101/102
ALTER TABLE `Usuarios` AUTO_INCREMENT = 103;

-- Conferência
SELECT `Id`, `Nome`, `Email`, `Perfil`, `Discriminator`, `Especialidade`
FROM `Usuarios`
WHERE `Id` IN (101, 102);
