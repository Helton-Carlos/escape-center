import api from './api';

interface UserData {
  name?: string;
  password: string;
  email: string;
}

export const userService = {
  register: async (userData: UserData) => {
    const response = await api.post('/users', userData);
    return response.data;
  },

  login: async (userData: UserData) => {
    const response = await api.post('/Login', userData);
    return response.data;
  },
};
