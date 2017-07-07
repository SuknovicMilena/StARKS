const webpack = require('webpack');
const webpackMerge = require('webpack-merge');
const commonConfig = require('./webpack.common.js');

module.exports = webpackMerge(commonConfig, {
  devtool: 'cheap-module-eval-source-map',

  output: {
    filename: '[name].js',
    chunkFilename: '[id].chunk.js'
  },

  module: {
    rules: [ ]
  },

  devServer: {
    historyApiFallback: true,
    stats: 'minimal',
    watchOptions: {
      ignored: /node_modules/
    }
  }
});
