# Cadastro dos 2 médicos pelo Swagger

**Endpoint:** `POST /api/Auth/cadastro`  
**Content-Type:** `application/json`

No Swagger: abra **Auth** → **POST /api/Auth/cadastro** → **Try it out** → cole o JSON no **Request body** → **Execute**.  
Repita uma vez para cada médico (primeiro Roberto, depois Amanda).

---

## 1º médico – Dr. Roberto Mendes

```json
{
  "nome": "Dr. Roberto Mendes",
  "email": "roberto@inova.pt",
  "senha": "123456",
  "perfil": "Profissional",
  "cpf": "34587633894",
  "telefone": "1192347258",
  "dataNascimento": "1980-01-01T00:00:00.000Z"
}
```

---

## 2º médico – Dra. Amanda Silva

```json
{
  "nome": "Dra. Amanda Silva",
  "email": "amanda@inova.pt",
  "senha": "123456",
  "perfil": "Profissional",
  "cpf": "98765432100",
  "telefone": "11987654321",
  "dataNascimento": "1985-05-15T00:00:00.000Z"
}
```

---

## Depois de cadastrar

1. Anote o **`id`** que a API devolve em cada resposta **200** (ex.: `1` e `2` se o banco estava vazio).
2. Use esse `id` como **`ProfissionalId`** em `POST /api/Agendamento` (não use `3` fixo do HTML antigo).
3. Login: `POST /api/Auth/login` com o mesmo `email` e `senha` de cada médico.

**Login de teste**

| Médico | E-mail | Senha |
|--------|--------|-------|
| Roberto | roberto@inova.pt | 123456 |
| Amanda | amanda@inova.pt | 123456 |
