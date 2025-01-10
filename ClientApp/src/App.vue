<script setup lang="ts">

import { ref } from 'vue';
import useAxios from './services/useAxios';
const { publicHttpClient: cliente } = useAxios();

const persona = ref({});

const obtenerPersona = async () => {
  const response = await cliente.get('https://localhost:7150/api/Personas');
  persona.value = response.data;
};
</script>

<template>
  <button @click="obtenerPersona">Obtener persona</button>
  
  <p>Persona: {{ persona }}</p>
</template>

<style scoped lang="scss">
p {
  color: red;
}
</style>
