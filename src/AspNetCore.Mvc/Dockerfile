FROM microsoft/aspnetcore-build
WORKDIR /release
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
COPY . /release
ENTRYPOINT ["dotnet", "AspNetCore.Mvc.dll"]