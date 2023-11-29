/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor,html}'],
  theme: {
      extend: {
        colors: {
          dark: {
            DEFAULT: "#181818", 
            foreground: "#ffffff", 
          },
          light: {
            DEFAULT: "#ffffff", 
            foreground: "#000000", 
          }, 
          primary: { 
            DEFAULT: "#32c06b", 
            foreground: "#32c06b", 
          }, 
          muted: { 
            DEFAULT: "hsl(var(--muted))", 
            foreground: "hsl(var(--muted-foreground))", 
          }, 
          cardTrasparent: { 
            DEFAULT: "#1414148e", 
          },
          card:{
            border: "#3938389c"
          },
          hover: {
            DEFAULT: "#ffffff", 
            foreground: "#000000",
          }  
        },

      },
  },
  plugins: [],
}

