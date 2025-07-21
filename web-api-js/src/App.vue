<template>
  <div>
    <!-- Cabeçalho -->
    <div class="login-header flex row col-12 q-my-md justify-center">
      <img alt="Vue logo" src="./assets/Image.png" style="width: 300px" />
    </div>
    <div v-if="!isAuthenticated" class="row col-12 justify-center">
      <form @submit.prevent="authenticate" class="row">
        <div class="col-12 q-mt-md">
          <q-input v-model="data.username" outlined bg-color="white" label="Usuário" dense />
        </div>
        <div class="col-12 q-mt-md">
          <q-input v-model="data.password" type="password" bg-color="white" outlined label="Senha" dense />
        </div>
        <div class="flex row col-12 justify-end q-pt-lg">
          <q-btn v-if="loading" type="submit" color="primary">
            <q-spinner-hourglass color="white" size="1.5rem" />
          </q-btn>
          <q-btn v-else type="submit" color="primary" label="Login" />
        </div>
      </form>
    </div>
    <div v-else class="column items-center q-mt-xl">
      <h6 class="q-mb-md" style="margin-top: -5%">Bem-vindo! Escolha uma opção:</h6>
      <q-btn class="q-my-sm" color="primary" label="Cadastrar Funcionário" @click="showCadastro = true" />
      <q-btn class="q-my-sm" color="secondary" label="Listar Funcionários" @click="listarFuncionarios" />
      <q-btn class="q-my-md" color="negative" label="Logout" @click="logout" />
    </div>
    <div v-if="showCadastro" class="column items-center">
      <h5>Cadastrar Funcionário</h5>
      <q-form @submit.prevent="cadastrarFuncionario" class="q-gutter-md">
        <q-input v-model="funcionario.nome" label="Nome" required />
        <q-input v-model="funcionario.idade" type="number" label="Idade" required />
        <q-input v-model="funcionario.cargo" label="Cargo" required />
        <q-btn label="Cadastrar" type="submit" color="primary" class="q-mt-md" />
      </q-form>
    </div>
    <div v-if="funcionarios.length > 0" class="column items-center q-mt-xl">
      <h5>Lista de Funcionários</h5>
      <q-table :rows="funcionarios" :columns="columns" row-key="id" />
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import LoginService from "@/services/LoginService";
import http from "@/http-common";

let loading = ref(false);
let data = ref({ username: "", password: "" });
let isAuthenticated = ref(false);
let showCadastro = ref(false);
let funcionarios = ref([]);
let funcionario = ref({ nome: "", idade: "", cargo: "" });

let columns = ref([
  { name: "nomeFuncionario", label: "Nome", align: "left", field: "nomeFuncionario" },
  { name: "idade", label: "Idade", align: "center", field: "idade" },
  { name: "cargo", label: "Cargo", align: "center", field: "cargo" },
]);

const _loginService = new LoginService();

onMounted(() => {
  const token = localStorage.getItem("token");
  if (token) {
    isAuthenticated.value = true;
    http.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  }
});

async function authenticate() {
  loading.value = true;
  try {
    const response = await _loginService.Login(data.value);
    const token = response.token;

    localStorage.setItem("token", token);
    http.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    isAuthenticated.value = true;
  } catch (error) {
    alert("Falha no login");
  } finally {
    loading.value = false;
  }
}

function logout() {
  localStorage.removeItem("token");
  isAuthenticated.value = false;
  http.defaults.headers.common["Authorization"] = null;
}

async function cadastrarFuncionario() {
  try {
    const formData = new FormData();
    formData.append("nome", funcionario.value.nome);
    formData.append("idade", funcionario.value.idade);
    formData.append("cargo", funcionario.value.cargo);

    await http.post("/api/v1/employee", formData, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem("token")}`,
        "Content-Type": "multipart/form-data",
      },
    });

    alert("Funcionário cadastrado com sucesso!");
    funcionario.value = { nome: "", idade: "", cargo: "" };
    showCadastro.value = false;
  } catch (error) {
    console.error(error);
    alert("Erro ao cadastrar funcionário.");
  }
}

async function listarFuncionarios() {
  try {
    const response = await http.get("/api/v1/employee", {
      headers: {
        Authorization: `Bearer ${localStorage.getItem("token")}`,
      },
      params: {
        pageNumber: 1,
        pageQuantity: 100,
      },
    });
    console.log("Dados recebidos da API:", response.data);

    funcionarios.value = response.data.map((funcionario) => ({
      id: funcionario.id,
      nomeFuncionario: funcionario.nomeFuncionario,
      cargo: funcionario.cargo,
      idade: funcionario.idade,
    }));

    console.log("Funcionários carregados:", funcionarios.value);
  } catch (error) {
    console.error("Erro ao listar funcionários:", error);
    alert("Erro ao listar funcionários.");
  }
}
</script>
