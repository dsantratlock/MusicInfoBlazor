module.exports = {
    purge: {
        enabled: true,
        content: ["./**/**/*.{razor,html,cshtml}"]
    },
  theme: {
      extend: {
          keyframes: {
              wiggle: {
                  '0%, 90%': { transform: 'rotate(-2deg)' },
                  '65%': { transform: 'rotate(5deg)' },
              }
          },
          animation: {
              wiggle: 'wiggle 1s ease-in-out infinite',
          }
      },
  },
  plugins: [],
}
