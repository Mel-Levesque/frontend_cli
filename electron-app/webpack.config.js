const path = require('path');
const nodeExternals = require('webpack-node-externals');

module.exports = {
  entry: './main.js', // Update with your actual renderer script filename
  target: 'electron-renderer',
  output: {
    filename: 'bundle.js', // Output filename
    path: path.resolve(__dirname, 'dist'), // Output directory
  },
  externals: [nodeExternals()],
};
