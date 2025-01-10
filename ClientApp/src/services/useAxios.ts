import { ref } from "vue";
import axios from "axios";

const useAxios = () => {
  const httpClient = axios.create({
    baseURL: import.meta.env.VITE_API_URI,
    withCredentials: true,
    headers: {
      "Content-Type": "application/json",
    },
  });

  const publicHttpClient = axios.create({
    baseURL: import.meta.env.VITE_API_URI,
    withCredentials: false,
    headers: {
      "Content-Type": "application/json",
    },
  });

  return { httpClient, publicHttpClient };
};

export default useAxios;
