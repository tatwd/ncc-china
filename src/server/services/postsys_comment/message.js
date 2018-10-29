var statusCodes = {
  succeeded: 0,
  failed: 1
}

module.exports = {
  statusCodes,
  succeeded(data, message) {
    return {
      code: statusCodes.succeeded,
      data,
      message: message ? `succeeded:${message}` : 'succeeded'
    }
  },
  failed(message) {
    return {
      code: statusCodes.failed,
      message: message ? `failed:${message}` : 'failed'
    }
  }
}