<template>
  <div class="recommendation-container">
    <h1>Banco de Alunos para Projetos</h1>
    <p>Descreva o projeto ou o perfil de aluno que você procura.</p>
    
    <div class="form-group">
      <textarea
        v-model="prompt"
        rows="5"
        placeholder="Ex: Preciso de um aluno com experiência em backend, C# e que tenha interesse em banco de dados para um projeto de API..."
      ></textarea>
    </div>

    <button @click="findStudents" :disabled="isLoading">
      {{ isLoading ? 'Buscando...' : 'Buscar Alunos' }}
    </button>

    <div v-if="error" class="error-message">
      <p>{{ error }}</p>
    </div>

    <div v-if="recommendedStudents.length > 0" class="results-container">
      <h2>Alunos Recomendados</h2>
      <ul>
        <li v-for="student in recommendedStudents" :key="student.studentID" class="student-card">
          <h3>{{ student.name }}</h3>
          <p><strong>Email:</strong> {{ student.email }}</p>
          <p><strong>CRAA:</strong> {{ student.craa }}</p>
          <p><strong>Descrição:</strong> {{ student.description || 'Nenhuma descrição fornecida.' }}</p>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { recommendationsService } from '@/services/recommendations'

// Estado reativo do componente
const prompt = ref('')
const recommendedStudents = ref([])
const isLoading = ref(false)
const error = ref(null)

// Função chamada pelo botão
const findStudents = async () => {
  if (!prompt.value.trim()) {
    error.value = 'Por favor, descreva o projeto antes de buscar.'
    return
  }

  isLoading.value = true
  error.value = null
  recommendedStudents.value = []

  try {
    // Chama nosso novo serviço
    const students = await recommendationsService.get(prompt.value)
    recommendedStudents.value = students
    if (students.length === 0) {
      error.value = "Nenhum aluno compatível foi encontrado com essa descrição."
    }
  } catch (e) {
    console.error(e)
    error.value = 'Ocorreu um erro ao buscar as recomendações. Tente novamente.'
  } finally {
    isLoading.value = false
  }
}
</script>

<style scoped>
/* Estilos para deixar a página bonita */
.recommendation-container {
  max-width: 800px;
  margin: 2rem auto;
  padding: 2rem;
  background-color: #f9f9f9;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0,0,0,0.1);
}
.form-group {
  margin-bottom: 1.5rem;
}
textarea {
  width: 100%;
  padding: 0.8rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 1rem;
}
button {
  padding: 0.8rem 1.5rem;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
}
button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}
.results-container {
  margin-top: 2rem;
}
.student-card {
  list-style-type: none;
  background-color: white;
  padding: 1.5rem;
  margin-bottom: 1rem;
  border-radius: 4px;
  border: 1px solid #eee;
}
.error-message {
  color: #d93025;
  margin-top: 1rem;
}
</style>