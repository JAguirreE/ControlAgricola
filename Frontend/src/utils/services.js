import axios from 'axios'
import qs from 'qs'

const HOST = 'https://localhost:44385/api/'

export class Services {
  static post (url, data) {
    return axios
      .post(HOST + url, data)
      .then(response => {
        return response.data
      })
      .catch(ex => {
        return Promise.reject(ex)
      })
  }

  static get (url, data) {
    return axios
      .get(HOST + url, {
        params: data,
        paramsSerializer: params => {
          return qs.stringify(params)
        }
      })
      .then(response => {
        return response.data
      })
      .catch(ex => {
        return Promise.reject(ex)
      })
  }
}
