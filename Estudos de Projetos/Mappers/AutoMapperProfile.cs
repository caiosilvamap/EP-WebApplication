
using AutoMapper;
using AutoMapper.Execution;
using SistemaCadastroProjeto.Models;
using SistemaCadastroProjeto.ViewModels;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaCadastroProjeto.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Objetivo, ObjetivoViewModel>().ReverseMap();

            CreateMap<Tema, TemaViewModel>().ReverseMap();

            CreateMap<Financiamento, FinanciamentoViewModel>().ReverseMap();

            CreateMap<Gerencia, GerenciaViewModel>().ReverseMap();

            CreateMap<GerenciaGeral, GerenciaGeralViewModel>().ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();

            CreateMap<TipoFuncao, TipoFuncaoViewModel>().ReverseMap();

            CreateMap<TipoCargo,TipoCargoViewModel>().ReverseMap();

            CreateMap<Arquivo, ArquivoViewModel>().ReverseMap();

            CreateMap<Projeto, ProjetoViewModel>()
                .ForMember(
                dest => dest.IdCliente,
                opt => opt.MapFrom(
                           src => src.UsuarioProjetos.Where(x => x.IdTipoFuncaoNavigation.Id == 1).Where(x => x.IdProjeto == src.Id).Select(x => x.IdUsuario).FirstOrDefault()))
                .ForMember(
                dest => dest.IdLTP,
                opt => opt.MapFrom(
                           src => src.UsuarioProjetos.Where(x => x.IdTipoFuncaoNavigation.Id == 2).Where(x => x.IdProjeto == src.Id).Select(x => x.IdUsuario).FirstOrDefault()))
                .ForMember(
                dest => dest.IdApoio,
                opt => opt.MapFrom(
                           src => src.UsuarioProjetos.Where(x => x.IdTipoFuncaoNavigation.Id == 3).Where(x => x.IdProjeto == src.Id).Select(x => x.IdUsuario).ToList()))

                .ForMember(
                 dest => dest.NomeCliente,
                 opt => opt.MapFrom(
                           src => src.UsuarioProjetos.Where(x => x.IdTipoFuncaoNavigation.Id == 1).Where(x => x.IdProjeto == src.Id).Select(x => x.IdUsuarioNavigation.Nome).FirstOrDefault()))
                .ForMember(
                 dest => dest.NomeLTP,
                 opt => opt.MapFrom(
                           src => src.UsuarioProjetos.Where(x => x.IdTipoFuncaoNavigation.Id == 2).Where(x => x.IdProjeto == src.Id).Select(x => x.IdUsuarioNavigation.Nome).FirstOrDefault()))
                .ForMember(
                 dest => dest.NomeApoio,
                 opt => opt.MapFrom(
                           src => src.UsuarioProjetos.Where(x => x.IdTipoFuncaoNavigation.Id == 3).Where(x => x.IdProjeto == src.Id).Select(x => x.IdUsuarioNavigation.Nome).ToList()))
                .ForMember(
                dest => dest.NomeArquivo,
                opt => opt.MapFrom(
                        src => src.LstArquivo.Where(x => x.IdProjeto == src.Id).Select(x => x.Nome).ToList()))
                .ForMember(
                dest => dest.LstArquivo,
                opt => opt.Ignore());

            CreateMap<ProjetoViewModel, Projeto>()
                .ForMember(
                dest => dest.LstArquivo,
                opt => opt.Ignore());
















        }
    }
}