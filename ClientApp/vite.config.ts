import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import mkcert from "vite-plugin-mkcert";

// https://vite.dev/config/
export default defineConfig({
    base: '/apitest/',
  server: {
    https: true,
      port: 3000,
      hmr: {
          port: 5173,
      },
  },
  plugins: [vue(), mkcert()],
})
