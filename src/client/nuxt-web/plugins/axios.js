import axios from 'axios'

export function fetch(config) {
  return new Promise((resolve,reject) => {
    const instance = axios.create({
      headers:{
        'Content-Type': 'application/json',
      },
      timeout: 5000,
      baseURL: 'http://192.168.1.103:5000/api/'
    });
    instance(config).then(res =>{
      console.log(res);
      resolve(res);
    }).catch(err => {
      console.log(err);
      reject(err);
    })
  });
}

export function getData(url,type,data) {
  if(type==='')
    type = 'post';
  return fetch({
    url: url,
    method: type,
    data: data,
  })
}
